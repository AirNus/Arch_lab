using Arch_lab.Models.DAL.Interfaces;

namespace Arch_lab.Models.DAL.Repositories
{
    public class PrivateKeyRepository : IBaseRepository<PrivateKey>
    {
        private readonly AppDbContext _appDbContext;

        public PrivateKeyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(PrivateKey entity)
        {
            await _appDbContext.PrivateKey.AddAsync(entity);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(PrivateKey entity)
        {
            _appDbContext.PrivateKey.Remove(entity);

            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<PrivateKey> GetAll()
        {
            return _appDbContext.PrivateKey;
        }

        public int GetMaxId()
        {
            return _appDbContext.PrivateKey.Max(x => x.Id);
        }
         

        public async Task<PrivateKey> Update(PrivateKey entity)
        {
            _appDbContext.PrivateKey.Update(entity);

            await _appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
