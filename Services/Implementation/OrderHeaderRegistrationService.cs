using AghaShad_Shop.DTOs;
using AghaShad_Shop.Forms;
using AghaShad_Shop.Models;
using AghaShad_Shop.Reopository.Interface;
using AghaShad_Shop.Services.Interface;

namespace AghaShad_Shop.Services.Implementation
{
    public class OrderHeaderRegistrationService : IOrderHeaderRegistrationService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderHeaderRepository _orderHeaderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderHeaderRegistrationService(ICustomerRepository customerRepository,
                                        IProductRepository productRepository,
                                        IOrderHeaderRepository orderHeaderRepository,
                                        IOrderDetailRepository orderDetailRepository
                                        )
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderHeaderRepository = orderHeaderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task RegisterOrderHeader(RegisterOrderForm form)
        {
            Customer? customer = await _customerRepository.GetCustomerById(form.CustomerId);
            if (customer == null) throw new Exception("User not found");

            Product product = await _productRepository.GetProductById(form.ProductId);
            if (product == null) throw new Exception("Product not found");

            RegisterOrderHeaderDto orderHeaderDto = new()
            {
                CustomerId = form.CustomerId,
                ShipperId = form.ShipperId,
            };
            int orderId = await _orderHeaderRepository.InsertOrderHeader(orderHeaderDto);
            
            RegisterOrderDetailDto orderDetailDto = new()
            {
                OrderId = orderId,
                ProductId = form.ProductId,
                Quantity = form.Quantity,
                Size = form.Size,
                UnitPrice = product.UnitPrice
            };
            await _orderDetailRepository.InsertOrderDetail(orderDetailDto);
        }
    }
}
