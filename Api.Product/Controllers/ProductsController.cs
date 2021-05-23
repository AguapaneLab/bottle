using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Product.DTO;
using Domain.Product.DTO.ResponseDTO;
using Domain.Product.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Api.Product.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [EnableCors("VmallPolicy")]
        [HttpPost]
        public ResponseDTO<ProductDTO> CreateProductAsync(ProductDTO product)
        {
            var response = new ResponseDTO<ProductDTO>();
            response = _productService.CreateProductAsync(product);
            return response;
        }
        [EnableCors("VmallPolicy")]
        [HttpPost]
        public long DisableProduct([FromBody] ProductDTO productDTO)
        {
            long disableCount = 0;
            disableCount = _productService.DisableProduct(productDTO._Id);
            return disableCount;
        }
        [EnableCors("VmallPolicy")]
        [HttpGet]
        public ResponseDTO<IEnumerable<ProductDTO>> GetAllProducts(string brand)
        {
            var products = new ResponseDTO<IEnumerable<ProductDTO>>();
            products = _productService.GetAllProducts(brand).Result;
            return products;
        }
        [EnableCors("VmallPolicy")]
        [HttpPost]
        public ProductDTO GetProductById([FromBody] ProductDTO productDTO)
        {
            var product = new ProductDTO();
            product = _productService.GetProductById(productDTO._Id);
            return product;
        }
        [EnableCors("VmallPolicy")]
        [HttpPost]
        public long UpdateProduct(ProductDTO product)
        {
            long updateCount = 0;
            updateCount = _productService.UpdateProduct(product);
            return updateCount;
        }
    }
}