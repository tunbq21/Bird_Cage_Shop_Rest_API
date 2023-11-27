
using AutoMapper;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.ProductEquipment;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IProductEquipmentService {
        public ProductEquipmentViewModel CreateProductEquipment(CreateProductEquipmentRequestModel productequipmentCreate);
        public ProductEquipmentViewModel UpdateProductEquipment(UpdateProductEquipmentRequestModel productequipmentUpdate);
        public bool DeleteProductEquipment(string idTmp);
        public List<ProductEquipmentViewModel> GetAll();
        public ProductEquipmentViewModel GetById(string idTmp);
    }

    public class ProductEquipmentService : IProductEquipmentService {

      private readonly IProductEquipmentRepository _productequipmentRepository;
        private readonly IMapper _mapper;

        public ProductEquipmentService(IProductEquipmentRepository productequipmentRepository, IMapper mapper)
        {
            _productequipmentRepository = productequipmentRepository;
            _mapper = mapper;
        }

        public ProductEquipmentViewModel CreateProductEquipment(CreateProductEquipmentRequestModel productequipmentCreate)
        {
            var productEquipment = _mapper.Map<ProductEquipment>(productequipmentCreate);
            productEquipment.ProductEquipmentId = Guid.NewGuid().ToString();

            _productequipmentRepository.Create(productEquipment);
            _productequipmentRepository.Save();

            return _mapper.Map<ProductEquipmentViewModel>(productEquipment);
        }

        public ProductEquipmentViewModel UpdateProductEquipment(UpdateProductEquipmentRequestModel productequipmentUpdate) 
        {
            var productEquipment = _productequipmentRepository.Get().SingleOrDefault(x => x.ProductEquipmentId.Equals(productequipmentUpdate.ProductEquipmentId));
            if (productEquipment == null) return null;
            productEquipment.ProductId = productequipmentUpdate.ProductId;
            productEquipment.EquipmentId = productequipmentUpdate.EquipmentId;

            _productequipmentRepository.Update(productEquipment);
            _productequipmentRepository.Save();

            return _mapper.Map<ProductEquipmentViewModel>(productEquipment);
        }

        public bool DeleteProductEquipment(string idTmp)
        {
            throw new NotImplementedException();
        }

        public List<ProductEquipmentViewModel> GetAll() 
        {
            throw new NotImplementedException();
        }

        public ProductEquipmentViewModel GetById(string idTmp) 
        {
            var productEquipment = _productequipmentRepository.Get().SingleOrDefault(x => x.ProductEquipmentId.Equals(idTmp));
            if (productEquipment == null) return null;
            return _mapper.Map<ProductEquipmentViewModel>(productEquipment);
        }

    }

}
