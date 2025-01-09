using Forestage.Models.Dtos.Products;
using Forestage.Models.Services;
using Forestage.Models.ViewModels.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MT.Utilities.Mapper;

namespace Forestage.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsApiController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{id}")]
        public ActionResult<ProductInfoVm> Get(int? id)
        {
            if (id == null) return NotFound();

            try
            {
                ProductInfoDto productInfoDto = _productService.Get(id.Value);
                ProductInfoVm productInfoVm = ObjectMapper.Map<ProductInfoDto, ProductInfoVm>(productInfoDto);
                return productInfoVm;
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
        }
    }
}
