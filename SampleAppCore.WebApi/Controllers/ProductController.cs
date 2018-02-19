using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleAppCore.Service.Interfaces;

namespace SampleAppCore.WebApi.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        IProductCategoryService _productCategoryService;
        public ProductController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_productCategoryService.GetAll());
        }

    }
}