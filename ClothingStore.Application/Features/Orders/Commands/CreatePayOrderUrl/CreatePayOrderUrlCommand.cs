using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Application.Features.Orders.Commands.CreateOrder;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Application.Libratires;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Orders.Commands.PayOrder
{
   
    public record CreatePayOrderUrlCommand : IRequest<Result<string>>
    {
        public int OrderId { get; set; }
       
    }
    
    internal class PayOrderCommandHandler : IRequestHandler<CreatePayOrderUrlCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PayOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<string>> Handle(CreatePayOrderUrlCommand command, CancellationToken cancellationToken)
        {
            Console.WriteLine(command.OrderId);
            var order = await _unitOfWork.Repository<Order>().Entities.Include(o => o.PaymentMethod).Where(o => o.Id == command.OrderId).FirstOrDefaultAsync();
            

            if(order == null)
            {
                return Result<string>.Failure("Order not found");
            }

            if(order.PaymentMethod.Name != "VNPAY")
            {
                return Result<string>.Failure("Payment method not valid!");
            }

            string paymentUrl = Generate_payment_url(order);


            return await Result<string>.SuccessAsync(paymentUrl, "Order Created");


        }

        private static string Generate_payment_url(Order order)
        {


            //Get Config Info
            /* string vnp_Returnurl = ConfigurationManager.AppSettings["vnp_Returnurl"]; //URL nhan ket qua tra ve 
             string vnp_Url = ConfigurationManager.AppSettings["vnp_Url"]; //URL thanh toan cua VNPAY 
             string vnp_TmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"]; //Ma định danh merchant kết nối (Terminal Id)
             string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Secret Key*/

            string vnp_Returnurl = "http://localhost:3000/checkout/payment/status"; //URL nhan ket qua tra ve 
            string vnp_Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html"; //URL thanh toan cua VNPAY 
            string vnp_TmnCode = "KHYQRSUM"; //Ma định danh merchant kết nối (Terminal Id)
            string vnp_HashSecret = "PWAICGXRXXIBIKXHNKFKLBVIVAUHZPAU"; //Secret Key

            /*  //Get payment input
              OrderInfo order = new OrderInfo();
              order.OrderId = DateTime.Now.Ticks; // Giả lập mã giao dịch hệ thống merchant gửi sang VNPAY
              order.Amount = 100000; // Giả lập số tiền thanh toán hệ thống merchant gửi sang VNPAY 100,000 VND
              order.Status = "0"; //0: Trạng thái thanh toán "chờ thanh toán" hoặc "Pending" khởi tạo giao dịch chưa có IPN
              order.CreatedDate = DateTime.Now;*/
            //Save order to db

            //Build URL for VNPAY
            VnPayLibrary vnpay = new();

            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (order.TotalAmount * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
            /*if (bankcode_Vnpayqr.Checked == true)
            {
                vnpay.AddRequestData("vnp_BankCode", "VNPAYQR");
            }
            else if (bankcode_Vnbank.Checked == true)
            {
                vnpay.AddRequestData("vnp_BankCode", "VNBANK");
            }
            else if (bankcode_Intcard.Checked == true)
            {
                vnpay.AddRequestData("vnp_BankCode", "INTCARD");
            }*/

            vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate?.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());


            vnpay.AddRequestData("vnp_Locale", "vn");

            /* else if (locale_En.Checked == true)
             {
                 vnpay.AddRequestData("vnp_Locale", "en");
             }*/

            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + order.Id);
            vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other

            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", order.Id.ToString()); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày

            //Add Params of 2.1.0 Version
            //Billing

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            return paymentUrl;
        }
    }
}
