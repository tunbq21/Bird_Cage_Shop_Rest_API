
using AutoMapper;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.OrderDetail;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IOrderDetailService {
        public List<OrderDetailViewModel> CreateOrderDetail(List<CreateOrderDetailRequestModel> orderdetailCreate);
        public OrderDetailViewModel UpdateOrderDetail(UpdateOrderDetailRequestModel orderdetailUpdate);
        public bool DeleteOrderDetail(string idTmp);
        public bool DeleteByOrderId(string idTmp);
        

        public List<OrderDetailViewModel> GetAll();
        public OrderDetailViewModel GetById(string idTmp);
        public List<OrderDetailViewModel> GetDetailByOrder(string orderId); 
        public List<OrderDetailViewModel> GetOrderDetailByUser(string userId); 




    }

    public class OrderDetailService : IOrderDetailService {

      private readonly IOrderDetailRepository _orderdetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderDetailService(IOrderDetailRepository orderdetailRepository,IProductRepository productRepository ,IMapper mapper)
        {
            _orderdetailRepository = orderdetailRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public List<OrderDetailViewModel> CreateOrderDetail(List<CreateOrderDetailRequestModel> orderdetailCreate)
        {
            var orderDetails = new List<OrderDetailViewModel>();
            foreach (var detailRequest in orderdetailCreate)
            {
                var orderDetail = _mapper.Map<OrderDetail>(detailRequest);
                orderDetail.OrderDetailId = Guid.NewGuid().ToString();

                _orderdetailRepository.Create(orderDetail);
                orderDetails.Add(_mapper.Map<OrderDetailViewModel>(orderDetail));

            }
                   
            _orderdetailRepository.Save();

            return orderDetails;

        }

        public OrderDetailViewModel UpdateOrderDetail(UpdateOrderDetailRequestModel orderdetailUpdate) 
        {
            var orderDetail = _orderdetailRepository.Get().SingleOrDefault(x => x.OrderDetailId.Equals(orderdetailUpdate.OrderDetailId));
            if (orderDetail == null) return null;
            orderDetail.Quantity = orderdetailUpdate.Quantity;

            _orderdetailRepository.Update(orderDetail);
            _orderdetailRepository.Save();

            return _mapper.Map<OrderDetailViewModel>(orderDetail);
        }

        public bool DeleteOrderDetail(String idTmp)
        {
            var orderDetail = _orderdetailRepository.Get().SingleOrDefault(x => x.OrderDetailId.Equals(idTmp));
            if(orderDetail == null) return false;
            _orderdetailRepository.Delete(orderDetail);
            _orderdetailRepository.Save();
            return true;
        }

        public List<OrderDetailViewModel> GetAll() 
        {
           var orderDetails = _orderdetailRepository.Get().Include(o => o.Product).ToList();
            return _mapper.Map<List<OrderDetailViewModel>>(orderDetails);
        }

        public OrderDetailViewModel GetById(string idTmp) 
        {
            var orderDetail = _orderdetailRepository.Get().Include(od => od.Product).SingleOrDefault(x => x.OrderDetailId.Equals(idTmp));
            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };

            var json = JsonSerializer.Serialize(orderDetail, jsonOptions);
            return _mapper.Map<OrderDetailViewModel>(orderDetail);
        }


        public bool DeleteByOrderId(string idTmp)
        {
            var orderDetail = _orderdetailRepository.Get().SingleOrDefault(x => x.OrderId.Equals(idTmp));
            if (orderDetail == null) return false;
            _orderdetailRepository.Delete(orderDetail);
            _orderdetailRepository.Save();
            return true;
        }

        public List<OrderDetailViewModel> GetDetailByOrder(string orderId)
        {
            var orderDetail = _orderdetailRepository.Get().Include(od => od.Product).Where(x => x.OrderId.Equals(orderId)).ToList();
            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };

            var json = JsonSerializer.Serialize(orderDetail, jsonOptions);
            return _mapper.Map<List<OrderDetailViewModel>>(orderDetail);
        }

        public List<OrderDetailViewModel> GetOrderDetailByUser(string userId)
        {
            throw new NotImplementedException();
        }
    }

}
