

using BirdCageShop.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.Product;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BirdCageShop.Presentation.Controllers 
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/products")]
    public class ProductController : ControllerBase {

        private IProductService _productService;

         public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<ProductViewModel> CreateProduct(CreateProductRequestModel productCreate)
        {
            var productCreated = _productService.CreateProduct(productCreate);

            if (productCreated == null)
            {
                return NotFound("Product invalid");
            }
            return productCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<ProductViewModel>> GetAll()
        {
            var productList = _productService.GetAll();

            if (productList == null)
            {
                return NotFound("Product not found");
            }
            return productList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<ProductViewModel> GetById(string idTmp)
        {
            var productDetail = _productService.GetById(idTmp);

            if (productDetail == null)
            {
                return NotFound("Product not found");
            }
            return productDetail;
        }

        [MapToApiVersion("1")]
        [HttpGet("productId")]
        public ActionResult<int> GetQuantityById(string idTmp)
        {
            var quantity = _productService.GetQuantityById(idTmp);

            if (quantity == null)
            {
                return NotFound("Product not found");
            }
            return quantity;
        }

        [MapToApiVersion("1")]
        [HttpGet("cateId")]
        public ActionResult<List<ProductViewModel>> GetProductByCategory(int cateId)
        {
            var productList = _productService.GetProductByCategory(cateId);

            if (productList == null)
            {
                return NotFound("Product not found");
            }
            return productList;
        }
        [MapToApiVersion("1")]
        [HttpGet("search")]
        public ActionResult<List<ProductViewModel>> SearchProduct(string name)
        {
            var productList = _productService.SearchProduct(name);

            if (productList == null)
            {
                return NotFound("Product not found");
            }
            return productList;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteProduct(string idTmp)
        {
            var check = _productService.DeleteProduct(idTmp);

            if (check == false)
            {
                return NotFound("Fail to delete Bird Cage");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<ProductViewModel> UpdateProduct(UpdateProductRequestModel productCreate)
        {
            var productUpdated = _productService.UpdateProduct(productCreate);

            if (productUpdated == null)
            {
                return NotFound("Fail to update Bird Cage");
            }
            return productUpdated;
        }
    }

}
