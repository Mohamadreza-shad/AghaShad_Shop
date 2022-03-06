using AghaShad_Shop.DTOs;
using AghaShad_Shop.Forms;
using AghaShad_Shop.Models;
using AghaShad_Shop.OutPut;

namespace AghaShad_Shop.Services.Interface
{
    public interface IProductService
    {
        Task InsertProduct(RegisterProductForm form);
        Task UpdateProduct(int id, RegisterProductForm form);
        Task DeleteProduct(int id);
        Task<ApiResponseResult<ProductOutput?>> GetProductById(int id);
        Task<ApiResponseResult<ProductOutput?>> GetProductByName(string name);
        Task<ApiResponseResult<List<ProductOutput?>>> GetAllProducts();

    }
}
