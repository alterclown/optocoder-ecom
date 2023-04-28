using OptoCoderEcommerceApi.Data.Context;
using OptoCoderEcommerceApi.Data.Entities;
using OptoCoderEcommerceApi.Data.Utilities;
using OptoCoderEcommerceApi.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace OptoCoderEcommerceApi.Repository.Ecommerce
{
    public interface IProductRepository
    {
        Task<ProductVm> Save(ProductVm model);
        Task<ResponseMessage> GetlProductFilteredByCategoryWithPagination(Expression<Func<Product, bool>> expression, int currentPage, int itemPerPage);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly OptocoderEcommerceContext _context;
        public ProductRepository(OptocoderEcommerceContext optocoderEcommerceContext)
        {
              _context = optocoderEcommerceContext;
        }

        public async Task<ResponseMessage> GetlProductFilteredByCategoryWithPagination(Expression<Func<Product, bool>> expression, int currentPage, int itemPerPage)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();

                currentPage = currentPage <= 0 ? AppConstant.InitialPage : currentPage;
                itemPerPage = itemPerPage <= 0 ? AppConstant.ItemPerPage : itemPerPage;

                int skip = (currentPage - 1) * itemPerPage;

                //pupolate Department list
                responseMessage.ResponseObj = await _context.Set<Product>().Where(expression).
                    OrderBy(x => x.ProductID).Skip(skip).Take(itemPerPage).ToListAsync();

                //count TotalItems by the search criteria
                responseMessage.Pagination.TotalItems = await _context.Set<Product>().Where(expression).CountAsync();
                responseMessage.Pagination.TotalPages = (int)Math.Ceiling(responseMessage.Pagination.TotalItems / (double)itemPerPage);

                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductVm> Save(ProductVm model)
        {
            try
            {
                ProductVm productVm = new ProductVm();
                productVm.product.ProductName = model.product.ProductName;
                productVm.product.ProductDescription = model.product.ProductDescription;
                productVm.product.CategoryID = model.product.CategoryID;
                productVm.product.Price = model.product.Price;
                productVm.product.ImageURL = model.product.ImageURL;
                productVm.product.Quantity = model.product.Quantity;

                _context.Product.Add(productVm.product);
                await _context.SaveChangesAsync();

                var product = await _context.Product.FindAsync(productVm.product.ProductName);

                foreach (var img in model.images)
                {
                    var images = new Images()
                    {
                        ImageName = img.ImageName,
                        ProductID = product.ProductID
                    };
                    _context.Image.Add(images);
                }
                await _context.SaveChangesAsync();
                productVm.product = product;
                productVm.images = model.images;
                return productVm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
