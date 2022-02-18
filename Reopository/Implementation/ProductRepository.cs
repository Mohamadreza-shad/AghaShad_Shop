using AghaShad_Shop.DataContext;
using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;
using AghaShad_Shop.Reopository.Interface;

namespace AghaShad_Shop.Reopository.Implementation
{
    public class ProductRepository : BaseRepository<Product,int>, IProductRepository
    {
        private readonly ShoppingContext _context;

        public ProductRepository(ShoppingContext context) : base(context)
        {
            _context = context;
        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task InsertProduct(RegisterProductForm form)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(int id, RegisterProductForm form)
        {
            throw new NotImplementedException();
        }
    }
}
