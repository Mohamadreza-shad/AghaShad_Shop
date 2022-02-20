using AghaShad_Shop.DataContext;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.Reopository.Implementation
{
    public class BaseRepository<TEntity, TKey> where TEntity : class
    {
        private readonly ShoppingContext _context;
        private readonly DbSet<TEntity> _dbset;

        public BaseRepository(ShoppingContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }

        public async Task AddAndSaveAsync(TEntity entity)
        {
            await _dbset.AddAsync(entity);
            await CommitAllChangesAsync();
        }

        public async Task UpdateAndSaveAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await CommitAllChangesAsync();
        }
        public async Task DeleteAndSaveAsync(TKey id)
        {
            TEntity? entity = await FindAsync(id);

            if (entity == null) throw new Exception("Entity not Found");

            _dbset.Remove(entity);
            await CommitAllChangesAsync();
        }

        public async Task<TEntity?> FindAsync(TKey id)
        {
            return await _dbset.FindAsync(id);
        } 

        public async Task CommitAllChangesAsync() => await _context.SaveChangesAsync();
    }
}
