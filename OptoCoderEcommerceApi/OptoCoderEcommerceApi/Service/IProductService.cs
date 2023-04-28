using Azure.Messaging;
using OptoCoderEcommerceApi.Data.Context;
using OptoCoderEcommerceApi.Data.Entities;
using OptoCoderEcommerceApi.Data.FilterEntities;
using OptoCoderEcommerceApi.Data.Utilities;
using OptoCoderEcommerceApi.Data.ViewModels;
using OptoCoderEcommerceApi.Repository.Ecommerce;
using OptoCoderEcommerceApi.Repository.Generics;
using OptocoderInventoryApi.Inventory.Repository.Generics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace OptoCoderEcommerceApi.Service
{
    public interface IProductService
    {
        Task<ResponseMessage> Save(RequestMessage requestMessage);
        Task<ResponseMessage> GetlProductFilteredByCategoryWithPagination(RequestMessage requestMessage);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseMessage> GetlProductFilteredByCategoryWithPagination(RequestMessage requestMessage)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                ProductFilter productFilter = JSONConvert.ConvertJsonToObject<ProductFilter>(requestMessage.RequestObj);

                var productList = await _productRepository.GetlProductFilteredByCategoryWithPagination(x => x.CategoryID == productFilter.CategoryID, requestMessage.CurrentPage, requestMessage.ItemPerPage);
                responseMessage.ResponseObj = productList;
                responseMessage.ResponseCode = (int)Enums.ResponseCode.Success;
                responseMessage.Message = "Success";
                responseMessage.IsUserMessage = true;
            }
            catch (Exception ex)
            {
                responseMessage.ResponseObj = null;
                responseMessage.ResponseCode = (int)Enums.ResponseCode.InternalServerError;
                responseMessage.Message = "Exception";
                responseMessage.IsUserMessage = false;
            }

            return responseMessage;
        }

        public async Task<ResponseMessage> Save(RequestMessage requestMessage)
        {
            ResponseMessage responseMessage = new ResponseMessage();

            try
            {
                ProductVm productVm = JSONConvert.ConvertJsonToObject<ProductVm>(requestMessage.RequestObj);
                if (productVm != null)
                {
                    var res = await _productRepository.Save(productVm);
                    responseMessage.ResponseObj = res;
                    responseMessage.ResponseCode = StatusCodes.Status200OK;
                    responseMessage.Message = "C";
                    responseMessage.IsUserMessage = false;
                    return responseMessage;

                }
                else {
                    responseMessage.ResponseObj = null;
                    responseMessage.ResponseCode = StatusCodes.Status204NoContent;
                    responseMessage.Message = "C";
                    responseMessage.IsUserMessage = false;
                    return responseMessage;
                }
            }
            catch (Exception ex)
            {
                responseMessage.ResponseObj = null;
                responseMessage.ResponseCode = StatusCodes.Status500InternalServerError;
                responseMessage.Message = "C";
                responseMessage.IsUserMessage = false;
            }

            return responseMessage;
        }
    }
}
