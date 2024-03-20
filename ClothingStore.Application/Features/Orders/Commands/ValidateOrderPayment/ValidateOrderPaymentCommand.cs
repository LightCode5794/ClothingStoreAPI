using AutoMapper;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Application.Libratires;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Orders.Commands.ValidateOrderPayment
{

    public record ValidateOrderPaymentCommand : IRequest<Result<bool>>
    {
        [Required]
        public decimal vnp_Amount { get; set; }
        [Required]
        public string vnp_BankCode { get; set; }

        public string? vnp_BankTranNo { get; set; }
        [Required]
        public string vnp_CardType { get; set; }
        [Required]
        public string vnp_OrderInfo { get; set; }
        [Required]
        public string vnp_PayDate { get; set; }
        [Required]
        public string vnp_ResponseCode { get; set; }
        [Required]
        public string vnp_TmnCode { get; set; }
        [Required]
        public int vnp_TransactionNo { get; set; }
        [Required]
        public string vnp_TransactionStatus { get; set; }
        [Required]
        public int vnp_TxnRef { get; set; }
        [Required]
        public string vnp_SecureHash { get; set; }

    }

    internal class ValidateOrderPaymentCommandHandler : IRequestHandler<ValidateOrderPaymentCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ValidateOrderPaymentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(ValidateOrderPaymentCommand command, CancellationToken cancellationToken)
        {


            VnPayLibrary vnPay = new();

            vnPay.AddResponseData("vnp_Amount", (command.vnp_Amount).ToString());
            vnPay.AddResponseData("vnp_BankCode", command.vnp_BankCode);
            vnPay.AddResponseData("vnp_BankTranNo", command.vnp_BankTranNo);
            vnPay.AddResponseData("vnp_CardType", command.vnp_CardType);
            vnPay.AddResponseData("vnp_OrderInfo", command.vnp_OrderInfo);
            vnPay.AddResponseData("vnp_PayDate", command.vnp_PayDate);
            vnPay.AddResponseData("vnp_ResponseCode", command.vnp_ResponseCode);
            vnPay.AddResponseData("vnp_TmnCode", command.vnp_TmnCode);
            vnPay.AddResponseData("vnp_TransactionNo", command.vnp_TransactionNo.ToString());
            vnPay.AddResponseData("vnp_TransactionStatus", command.vnp_TransactionStatus);
            vnPay.AddResponseData("vnp_TxnRef", command.vnp_TxnRef.ToString());


            long orderId = Convert.ToInt64(vnPay.GetResponseData("vnp_TxnRef"));
            long vnp_Amount = Convert.ToInt64(vnPay.GetResponseData("vnp_Amount")) / 100;
            long vnpayTranId = Convert.ToInt64(vnPay.GetResponseData("vnp_TransactionNo"));
            string vnp_ResponseCode = vnPay.GetResponseData("vnp_ResponseCode");
            string vnp_TransactionStatus = vnPay.GetResponseData("vnp_TransactionStatus");

            string hashSecret = "PWAICGXRXXIBIKXHNKFKLBVIVAUHZPAU";
            bool isValidSignature = vnPay.ValidateSignature(command.vnp_SecureHash, hashSecret);

            if (isValidSignature)
            {
                var order = await _unitOfWork.Repository<Order>().GetByIdAsync(command.vnp_TxnRef);

                if (order == null)
                {
                    return Result<bool>.Failure("Order not found");
                }
                if (order.TotalAmount != vnp_Amount)
                {
                    return Result<bool>.Failure("Invalid amount");
                }

                if (order.Status != "pending")
                {

                    return Result<bool>.Failure("Order already confirmed");
                }

                if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                {
                    //Thanh toan thanh cong
                    order.Status = "completed";

                }
                else
                {
                    //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
                    //  displayMsg.InnerText = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;

                    order.Status = "canceled";

                    await _unitOfWork.Repository<Order>().UpdateAsync(order);
                    await _unitOfWork.Save(cancellationToken);
                    return await Result<bool>.FailureAsync(false, $"Thanh toan  loi {order.Status}, OrderId={orderId}, VNPAY TranId={vnpayTranId}, ResponseCode={vnp_ResponseCode}");


                }
                await _unitOfWork.Repository<Order>().UpdateAsync(order);
                await _unitOfWork.Save(cancellationToken);
                return Result<bool>.Success(true, "Payment completed");

            }
            else
            {

                return Result<bool>.Success(false, "Invalid signature");
            }

        }


    }
}