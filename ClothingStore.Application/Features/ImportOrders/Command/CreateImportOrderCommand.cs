using AutoMapper;
using ClothingStore.Application.Features.Orders.Commands.CreateOrder;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.ImportOrders.Command
{
    public record CreateImportOrderCommand : IRequest<Result<int>>
    {
        [Required]
        public ItemImportDto[] OldProducts { get; set; }
        public ItemImportDto[] NewProducts { get; set; }
        [Required]
        public int ProductId { get; set; }
        
    }

    internal class CreateImportOrderCommandHandler : IRequestHandler<CreateImportOrderCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateImportOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(CreateImportOrderCommand command, CancellationToken cancellationToken)
        {

                
            //await _unitOfWork.Repository<ImportOrder>().AddAsync(newOder);
           // newOder.AddDomainEvent(new OrderCreatedEvent(newOder));
           // await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(1, "Import order Created");


        }
    }
}
