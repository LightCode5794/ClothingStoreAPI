﻿// <auto-generated />
using System;
using ClothingStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClothingStore.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231231062043_v9_db")]
    partial class v9_db
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClothingStore.Domain.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.CartDetail", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("integer");

                    b.Property<int>("SizeOfColorId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("CartId", "SizeOfColorId");

                    b.HasIndex("SizeOfColorId");

                    b.ToTable("Cart_Detail");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.FavoriteProduct", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("FavoriteProduct");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.ImportOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ImportOrder");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.ImportOrderDetail", b =>
                {
                    b.Property<int>("ImportOderId")
                        .HasColumnType("integer");

                    b.Property<int>("SizeOfColorId")
                        .HasColumnType("integer");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("VoucherId")
                        .HasColumnType("integer");

                    b.HasKey("ImportOderId", "SizeOfColorId");

                    b.HasIndex("SizeOfColorId");

                    b.HasIndex("VoucherId");

                    b.ToTable("ImportOrder_Detail");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("integer");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("VoucherId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("VoucherId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OderId")
                        .HasColumnType("integer");

                    b.Property<int>("SizeOfColorId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("VoucherId")
                        .HasColumnType("integer");

                    b.HasKey("OderId", "SizeOfColorId");

                    b.HasIndex("SizeOfColorId");

                    b.HasIndex("VoucherId");

                    b.ToTable("Order_Detail");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Payment_Method");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("DiscountPercent")
                        .HasColumnType("numeric");

                    b.Property<decimal>("FixedPrice")
                        .HasColumnType("numeric");

                    b.Property<string[]>("Images")
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductDetail");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Review", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string[]>("Images")
                        .HasColumnType("text[]");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.SizeOfColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ProductDetailId")
                        .HasColumnType("integer");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProductDetailId");

                    b.ToTable("SizeOfColor");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Voucher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Voucher");
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.Property<int>("PermissionsId")
                        .HasColumnType("integer");

                    b.Property<int>("RolesId")
                        .HasColumnType("integer");

                    b.HasKey("PermissionsId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("PermissionRole");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Cart", b =>
                {
                    b.HasOne("ClothingStore.Domain.Entities.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("ClothingStore.Domain.Entities.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.CartDetail", b =>
                {
                    b.HasOne("ClothingStore.Domain.Entities.Cart", "Cart")
                        .WithMany("ProductsLink")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingStore.Domain.Entities.SizeOfColor", "SizeOfColor")
                        .WithMany("CartsLink")
                        .HasForeignKey("SizeOfColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("SizeOfColor");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.FavoriteProduct", b =>
                {
                    b.HasOne("ClothingStore.Domain.Entities.Product", "Product")
                        .WithMany("FavoriteUsersLink")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingStore.Domain.Entities.User", "User")
                        .WithMany("FavoriteProductsLink")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.ImportOrder", b =>
                {
                    b.HasOne("ClothingStore.Domain.Entities.Product", "Product")
                        .WithMany("ImportOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.ImportOrderDetail", b =>
                {
                    b.HasOne("ClothingStore.Domain.Entities.ImportOrder", "ImportOder")
                        .WithMany("ProductsDetailsLink")
                        .HasForeignKey("ImportOderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingStore.Domain.Entities.SizeOfColor", "SizeOfColor")
                        .WithMany("ImportOdersLink")
                        .HasForeignKey("SizeOfColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingStore.Domain.Entities.Voucher", "Voucher")
                        .WithMany()
                        .HasForeignKey("VoucherId");

                    b.Navigation("ImportOder");

                    b.Navigation("SizeOfColor");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Order", b =>
                {
                    b.HasOne("ClothingStore.Domain.Entities.User", "Customer")
                        .WithMany("OdersList")
                        .HasForeignKey("CustomerId");

                    b.HasOne("ClothingStore.Domain.Entities.PaymentMethod", "PaymentMethod")
                        .WithMany("Order")
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingStore.Domain.Entities.Voucher", "Voucher")
                        .WithMany("OdersUsed")
                        .HasForeignKey("VoucherId");

                    b.Navigation("Customer");

                    b.Navigation("PaymentMethod");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("ClothingStore.Domain.Entities.Order", "Oder")
                        .WithMany("ProductsLink")
                        .HasForeignKey("OderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingStore.Domain.Entities.SizeOfColor", "Product")
                        .WithMany("OdersLink")
                        .HasForeignKey("SizeOfColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingStore.Domain.Entities.Voucher", "Voucher")
                        .WithMany()
                        .HasForeignKey("VoucherId");

                    b.Navigation("Oder");

                    b.Navigation("Product");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("ClothingStore.Domain.Entities.Category", "Category")
                        .WithMany("ProductsLink")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingStore.Domain.Entities.Product", "Product")
                        .WithMany("CategoriesLink")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.ProductDetail", b =>
                {
                    b.HasOne("ClothingStore.Domain.Entities.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Review", b =>
                {
                    b.HasOne("ClothingStore.Domain.Entities.Order", "Order")
                        .WithOne("Review")
                        .HasForeignKey("ClothingStore.Domain.Entities.Review", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingStore.Domain.Entities.Product", "Product")
                        .WithMany("UserReviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingStore.Domain.Entities.User", "User")
                        .WithMany("ProductReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.SizeOfColor", b =>
                {
                    b.HasOne("ClothingStore.Domain.Entities.ProductDetail", "ProductDetail")
                        .WithMany("Sizes")
                        .HasForeignKey("ProductDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("ClothingStore.Domain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingStore.Domain.Entities.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.User", b =>
                {
                    b.HasOne("ClothingStore.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.HasOne("ClothingStore.Domain.Entities.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingStore.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Cart", b =>
                {
                    b.Navigation("ProductsLink");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Category", b =>
                {
                    b.Navigation("ProductsLink");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.ImportOrder", b =>
                {
                    b.Navigation("ProductsDetailsLink");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Order", b =>
                {
                    b.Navigation("ProductsLink");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.PaymentMethod", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Product", b =>
                {
                    b.Navigation("CategoriesLink");

                    b.Navigation("FavoriteUsersLink");

                    b.Navigation("ImportOrders");

                    b.Navigation("ProductDetails");

                    b.Navigation("UserReviews");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.ProductDetail", b =>
                {
                    b.Navigation("Sizes");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.SizeOfColor", b =>
                {
                    b.Navigation("CartsLink");

                    b.Navigation("ImportOdersLink");

                    b.Navigation("OdersLink");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.User", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("FavoriteProductsLink");

                    b.Navigation("OdersList");

                    b.Navigation("ProductReviews");
                });

            modelBuilder.Entity("ClothingStore.Domain.Entities.Voucher", b =>
                {
                    b.Navigation("OdersUsed");
                });
#pragma warning restore 612, 618
        }
    }
}
