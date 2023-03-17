using Arch_lab.Models.DAL.Interfaces;

namespace Arch_lab.Models.DAL.Repositories
{
    public class PublicKeyRepository : IBaseRepository<PublicKey>
    {
        private readonly AppDbContext _appDbContext;

        public PublicKeyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(PublicKey entity)
        {
            await _appDbContext.PublicKey.AddAsync(entity);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(PublicKey entity)
        {
            _appDbContext.PublicKey.Remove(entity);

            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<PublicKey> GetAll()
        {
            return _appDbContext.PublicKey;
        }

        public int GetMaxId()
        {
            return _appDbContext.PublicKey.Max(x => x.Id);
        }

        public async Task<PublicKey> Update(PublicKey entity)
        {
            _appDbContext.PublicKey.Update(entity);

            await _appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
