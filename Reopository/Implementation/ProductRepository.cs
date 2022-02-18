using AghaShad_Shop.DataContext;
using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;
using AghaShad_Shop.Reopository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.Reopository.Implementation
{
    public class ProductRepository : BaseRepository<Product,int>, IProductRepository
    {
        private readonly ShoppingContext _context;

        public ProductRepository(ShoppingContext context) : base(context)
        {
            _context = context;
        }

        public Task DeleteProduct(int id) => DeleteAndSaveAsync(id);

        public async Task<List<Product>> GetAllProducts() => await _context.Products.ToListAsync();

        public async Task<Product> GetProductById(int id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);

            if (product == null) throw new Exception("Product not found");
            return product;
        }

        public async Task<Product> GetProductByName(string name)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(product => product.Name == name);

            if (product == null) throw new Exception("Product not found");
            return product;
        }

        public async Task InsertProduct(RegisterProductForm form)
        {
            Product product = new()
            {
                Name = form.Name,
                Color = form.Color,
                Size = form.Size
            };

            await AddAndSaveAsync(product);
        }

        public async Task UpdateProduct(int id, RegisterProductForm form)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null) throw new Exception("Product not found");

            product.Name = form.Name;
            product.Color = form.Color;
            product.Size = form.Size;

            await UpdateAndSaveAsync(product);
        }
    }
}
