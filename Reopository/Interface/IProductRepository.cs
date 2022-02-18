using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;

namespace AghaShad_Shop.Reopository.Interface
{
    public interface IProductRepository
    {
        Task InsertProduct(RegisterProductForm form);
        Task UpdateProduct(int id, RegisterProductForm form);
        Task DeleteProduct(int id);
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByName(string name);
        Task<List<Product>> GetAllProducts();

    }
}
