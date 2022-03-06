using AghaShad_Shop.DTOs;
using AghaShad_Shop.Errors;
using AghaShad_Shop.Forms;
using AghaShad_Shop.Models;
using AghaShad_Shop.OutPut;
using AghaShad_Shop.Reopository.Interface;
using AghaShad_Shop.Services.Interface;
using System.Net;

namespace AghaShad_Shop.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task DeleteProduct(int id) => await _productRepository.DeleteProduct(id);
        
        public Task<ApiResponseResult<List<ProductOutput?>>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponseResult<ProductOutput?>> GetProductById(int id)
        {
            Product? product = await _productRepository.GetProductById(id);

            if(product == null)
            {
                return new ApiResponseResult<ProductOutput?>
                {
                    Error = Error.ProductNotFound,
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }

            return new ApiResponseResult<ProductOutput?>
            {
                Result = new ProductOutput
                {
                    Color = product.Color,
                    Name = product.Name,
                    Size = product.Size,
                    UnitPrice = product.UnitPrice
                },
                HttpStatusCode = HttpStatusCode.OK
            };
        }

        public async Task<ApiResponseResult<ProductOutput?>> GetProductByName(string name)
        {
            Product? product = await _productRepository.GetProductByName(name);

            if (product == null)
            {
                return new ApiResponseResult<ProductOutput?>
                {
                    Error = Error.ProductNotFound,
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }

            return new ApiResponseResult<ProductOutput?>
            {
                Result = new ProductOutput
                {
                    Color = product.Color,
                    Name = product.Name,
                    Size = product.Size,
                    UnitPrice = product.UnitPrice
                },
                HttpStatusCode = HttpStatusCode.OK
            };
        }

        public async Task InsertProduct(RegisterProductForm form)
        {
            RegisterProductDto registerProductDto = new()
            {
                Name = form.Name,
                Color = form.Color,
                Size = form.Size,
                UnitPrice = form.UnitPrice
            };

            await _productRepository.InsertProduct(registerProductDto);
        }

        public async Task UpdateProduct(int id, RegisterProductForm form)
        {
            RegisterProductDto registerProductDto = new()
            {
                Name = form.Name,
                Color = form.Color,
                Size = form.Size,
                UnitPrice = form.UnitPrice
            };
            await _productRepository.UpdateProduct(id, registerProductDto);
        }
    }
}
