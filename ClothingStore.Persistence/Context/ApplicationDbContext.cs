using ClothingStore.Domain.Common;
using ClothingStore.Domain.Common.Interfaces;
using ClothingStore.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace ClothingStore.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
          IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<User> User => Set<User>();
        public DbSet<Permission> Permission => Set<Permission>();
        public DbSet<Role> Role => Set<Role>();
        public DbSet<Category> Category => Set<Category>();
        public DbSet<Product> Product => Set<Product>();
        
        public DbSet<ProductCategory> ProductCategory => Set<ProductCategory>();
        public DbSet<Cart> Cart => Set<Cart>();
        public DbSet<CartDetail> Cart_Detail => Set<CartDetail>();
        public DbSet<ImportOrder> ImportOrder => Set<ImportOrder>();
        public DbSet<ImportOrderDetail> ImportOrder_Detail => Set<ImportOrderDetail>();
        public DbSet<Order> Order => Set<Order>();
        public DbSet<OrderDetail> Order_Detail => Set<OrderDetail>();
        public DbSet<PaymentMethod> Payment_Method => Set<PaymentMethod>();
        public DbSet<Transaction> Transaction => Set<Transaction>();
        public DbSet<Voucher> Voucher => Set<Voucher>();
        public DbSet<Review> Review => Set<Review>();
        public DbSet<FavoriteProduct> FavoriteProduct => Set<FavoriteProduct>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //set unique
            modelBuilder.Entity<Category>()
               .HasIndex(e => e.Name)
               .IsUnique(true);

            // Indirect many-to-many setup for User review food
            modelBuilder.Entity<Review>()
           .HasKey(x => new { x.UserId, x.ProductId });

            // Indirect many-to-many setup for Oder and Food
            modelBuilder.Entity<OrderDetail>()
            .HasKey(x => new { x.OderId, x.SizeOfColorId });

            modelBuilder.Entity<CartDetail>()
            .HasKey(x => new { x.CartId, x.SizeOfColorId});

            modelBuilder.Entity<ProductCategory>()
            .HasKey(x => new { x.ProductId, x.CategoryId });

            modelBuilder.Entity<FavoriteProduct>()
            .HasKey(x => new { x.UserId, x.ProductId });

            modelBuilder.Entity<ImportOrderDetail>()
            .HasKey(x => new { x.ImportOderId, x.SizeOfColorId });

            

            // one to one 
            /*modelBuilder.Entity<Order>()
            .HasOne(o => o.Transaction)
            .WithOne(t => t.Order)
            .HasForeignKey<Transaction>(t => t.OrderId)
            .IsRequired();*/

            modelBuilder.Entity<Order>()
            .HasOne(o => o.Review)
            .WithOne(t => t.Order)
            .HasForeignKey<Review>(t => t.OrderId)
            .IsRequired();

            modelBuilder.Entity<User>()
           .HasOne(o => o.Cart)
           .WithOne(t => t.User)
           .HasForeignKey<Cart>(t => t.UserId)
           .IsRequired();


        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
