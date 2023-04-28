using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptoCoderEcommerceApi.Data.Utilities;
using OptoCoderEcommerceApi.Data.ViewModels;
using OptoCoderEcommerceApi.Service;

namespace OptoCoderEcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #region Insert Product and images One to Many
        [HttpPost]
        [Route("SaveProduct")]
        public async Task<IActionResult> SaveProduct(RequestMessage requestMessage)
        {

            try
            {
                var response = await _productService.Save(requestMessage);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion


        #region get product list by category
        [HttpGet]
        [Route("GetProuctListByCategory")]
        public async Task<IActionResult> GetProuctListByCategory(RequestMessage requestMessage)
        {

            try
            {
                var response = await _productService.GetlProductFilteredByCategoryWithPagination(requestMessage);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
