

using AutoMapper;
using BirdCageShop.BusinessLogic.Enums;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Product;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IProductService {
        public ProductViewModel CreateProduct(CreateProductRequestModel productCreate);
        public ProductViewModel UpdateProduct(UpdateProductRequestModel productUpdate);
        public bool DeleteProduct(string idTmp);
        public List<ProductViewModel> GetAll();
        public List<ProductViewModel> GetProductByCategory(int idtmp);
        public List<ProductViewModel> SearchProduct(string name);
        public ProductViewModel GetById(string idTmp);
        public int GetQuantityById(string idTmp);
    }

    public class ProductService : IProductService {

      private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper )
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }

        public ProductViewModel CreateProduct(CreateProductRequestModel productCreate)
        {
            var product = _mapper.Map<Product>(productCreate);
            product.ProductId = Guid.NewGuid().ToString();
            product.Status = (int?)ProductStatusEnum.availible;

            _productRepository.Create(product);
            _productRepository.Save();

            return _mapper.Map<ProductViewModel>(product);


        }

        public ProductViewModel UpdateProduct(UpdateProductRequestModel productUpdate) 
        {
            var product = _productRepository.Get().SingleOrDefault(x => x.ProductId.Equals(productUpdate.ProductId));
            if (product == null) return null;
            product.ProductName = productUpdate.ProductName;           
            product.Model = productUpdate.Model;
            product.Price = productUpdate.Price;
            product.BirdTypeId = productUpdate.BirdTypeId;
            product.Description = productUpdate.Description;
            product.Status = productUpdate.Status;
            product.Size = productUpdate.Size;
            product.Quantity = productUpdate.Quantity;
            product.ProductMaterial = productUpdate.ProductMaterial;
            product.BirdCageType = productUpdate.BirdCageType;
            product.Image = productUpdate.Image;
            product.Color = productUpdate.Color;
            product.Sale = productUpdate.Sale;
    

            _productRepository.Update(product);
            _productRepository.Save();

            return _mapper.Map<ProductViewModel>(product);

        }

        public bool DeleteProduct(string idTmp)
        {
            var product = _productRepository.Get().SingleOrDefault(x => x.ProductId.Equals(idTmp));
            if (product == null) return false;
            product.Status = (int?)ProductStatusEnum.unavailible;

            _productRepository.Update(product);
            _productRepository.Save();

            return true;
        }

        public List<ProductViewModel> GetAll() 
        {
            var products = _productRepository.Get().ToList();
            return _mapper.Map<List<ProductViewModel>>(products);
        }

        public ProductViewModel GetById(string idTmp) 
        {
            var product = _productRepository.Get().SingleOrDefault(x => x.ProductId.Equals(idTmp));
            if (product == null) return null;

            return _mapper.Map<ProductViewModel>(product);
        }

        public int GetQuantityById(string idTmp)
        {
            var product = _productRepository.Get().SingleOrDefault(x => x.ProductId.Equals(idTmp));
            if (product != null) return (int)product.Quantity;

            return -1;
        }

      
        public List<ProductViewModel> GetProductByCategory(int idTmp)
        {
            var productList = _productRepository.Get().Where(product => product.BirdTypeId == idTmp).ToList();
            if (productList == null) return null;

            return _mapper.Map<List<ProductViewModel>>(productList);
        }
        public List<ProductViewModel> SearchProduct(string name)
        {
            var productList = _productRepository.Get().Where(product => product.ProductName.ToLower().Contains(name.ToLower())).ToList();
            if (productList == null) return null;

            return _mapper.Map<List<ProductViewModel>>(productList);
        }
    }

}
