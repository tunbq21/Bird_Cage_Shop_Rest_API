
using AutoMapper;
using BirdCageShop.BusinessLogic.Enums;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Order;
using Ecommerce.BusinessLogic.RequestModels.OrderDetail;
using Ecommerce.BusinessLogic.RequestModels.Product;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IOrderService {
        public OrderViewModel CreateOrder(CreateOrderRequestModel orderCreate/*, List<CreateOrderDetailRequestModel> orderDetails*/);
        public OrderViewModel UpdateOrder(UpdateOrderRequestModel orderUpdate);
        public OrderViewModel UpdateOrderById(UpdateOrderByIdRequestModel orderStatusUpdate);
        public OrderViewModel AssignEmployee(AssignEmpRequestModel assignEmpRequest);
        

        public bool DeleteOrder(string idTmp);
        public List<OrderViewModel> GetAll();
        public OrderViewModel GetById(string orderId);
        public List<OrderViewModel> GetByUserId(string userId);
        public List<OrderViewModel> GetOrderByEmpId(string empId);

    }

    public class OrderService : IOrderService {

        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository; 
        private readonly IProductRepository _productRepository;
        private readonly IOrderDetailService _orderDetailService;
 
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IUserService userService, IOrderDetailService orderDetailService, IOrderDetailRepository orderDetailRepository, IProductService productService,IProductRepository productRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository; 
            _orderDetailService = orderDetailService;
            _orderDetailRepository = orderDetailRepository;       
            _productRepository = productRepository;
        }

        public OrderViewModel CreateOrder(CreateOrderRequestModel orderCreate)
        {
            try
            {
                var order = _mapper.Map<Order>(orderCreate);

                order.OrderId = Guid.NewGuid().ToString();
                order.OrderDate = DateTime.Now;
                order.OrderStatus = (int?)OrderStatusEnum.Pending;
                order.ExpectedDeliveryDate = DateTime.Now.AddDays(2);

                _orderRepository.Create(order);
                _orderRepository.Save();

                foreach (var cart in orderCreate.orderDetail)
                {
                    var orderDetail = _mapper.Map<OrderDetail>(orderCreate.orderDetail);

                    orderDetail.OrderDetailId = Guid.NewGuid().ToString();
                    orderDetail.OrderId = order.OrderId;
                    orderDetail.ProductId = cart.ProductId;
                    orderDetail.Quantity = cart.CartQuantity;

                    _orderDetailRepository.Create(orderDetail);
                    _orderDetailRepository.Save();
                }
               

                return _mapper.Map<OrderViewModel>(order);
            }
            catch(Exception ex)
            {
               throw ex;
            }
            
        }

        public OrderViewModel UpdateOrder(UpdateOrderRequestModel orderUpdate) 
        {
            var order = _orderRepository.Get().SingleOrDefault(x => x.OrderId.Equals(orderUpdate.OrderId));
            if (order == null) return null;

            order.OrderStatus = orderUpdate.OrderStatus;

            if(orderUpdate.OrderStatus == (int)OrderStatusEnum.Cancelled)
            {
                _orderDetailService.DeleteByOrderId(orderUpdate.OrderId);
            }

            _orderRepository.Update(order);
            _orderRepository.Save();

            return _mapper.Map<OrderViewModel>(order);
        }

        public bool DeleteOrder(string idTmp)
        {
            var order = _orderRepository.Get().SingleOrDefault(x => x.OrderId.Equals(idTmp));
            if (order == null) return false;
            order.OrderStatus = (int?)OrderStatusEnum.Cancelled;

            _orderRepository.Update(order);
            _orderRepository.Save();

            return true;
        }

        public List<OrderViewModel> GetAll() 
        {
           var orders = _orderRepository.Get().Include(o => o.User).ToList();
            return _mapper.Map<List<OrderViewModel>>(orders);
        }

        public OrderViewModel GetById(string orderId) 
        {
            var order = _orderRepository.Get().SingleOrDefault(x => x.OrderId.Equals(orderId));
            if (order == null) return null;
            return _mapper.Map<OrderViewModel>(order);
        }

        public List<OrderViewModel> GetByUserId(string userId)
        {
            var order = _orderRepository.Get().Include(o => o.User).Where(x => x.UserId.Equals(userId)).ToList();
            if (order == null) return null;

            return _mapper.Map<List<OrderViewModel>>(order);
        }

        public OrderViewModel UpdateOrderById(UpdateOrderByIdRequestModel orderStatusUpdate)
        {
            var order = _orderRepository.Get().Include(o => o.User ).SingleOrDefault(x => x.OrderId.Equals(orderStatusUpdate.OrderId));
            if (orderStatusUpdate.OrderStatus.Equals("Pending")){
                order.OrderStatus = (int?)OrderStatusEnum.Pending;
            }else if (orderStatusUpdate.OrderStatus.Equals("Processing")){
                order.OrderStatus = (int?)OrderStatusEnum.Processing;
            }
            else if (orderStatusUpdate.OrderStatus.Equals("Shipped")){
                order.OrderStatus = (int?)OrderStatusEnum.Shipped;
            }
            else if (orderStatusUpdate.OrderStatus.Equals("Delivered")){
                order.OrderStatus = (int?)OrderStatusEnum.Delivered;
                var orderDetail = _orderDetailService.GetDetailByOrder(order.OrderId);
                foreach (var item in orderDetail)
                {
                    var product = _productRepository.Get().SingleOrDefault(x => x.ProductId.Equals(item.ProductId));
                    product.Quantity -= item.Quantity;
                    _productRepository.Update(product);
                    _productRepository.Save();

                }
            }
            else if (orderStatusUpdate.OrderStatus.Equals("Cancelled")){
                order.OrderStatus = (int?)OrderStatusEnum.Cancelled;
            }
            _orderRepository.Update(order);
            _orderRepository.Save();

            return _mapper.Map<OrderViewModel>(order);
        }

        public OrderViewModel AssignEmployee(AssignEmpRequestModel assignEmpRequest)
        {
            var order = _orderRepository.Get().Include(o => o.User).SingleOrDefault(x => x.OrderId.Equals(assignEmpRequest.OrderId));
            if (order == null) return null;
         
            order.AssignedEmp = assignEmpRequest.UserId;

            _orderRepository.Update(order);
            _orderRepository.Save();

            return _mapper.Map<OrderViewModel>(order);
        }

        public List<OrderViewModel> GetOrderByEmpId(string empId)
        {
            var order = _orderRepository.Get().Where(x => x.AssignedEmp.Equals(empId)).ToList();
            if (order == null) return null;

            return _mapper.Map<List<OrderViewModel>>(order);
        }
    }

}
