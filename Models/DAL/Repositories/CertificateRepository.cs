using Arch_lab.Models.DAL.Interfaces;

namespace Arch_lab.Models.DAL.Repositories
{
    public class CertificateRepository : IBaseRepository<Certificate>
    {
        private readonly AppDbContext _appDbContext;

        public CertificateRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(Certificate entity)
        {
            await _appDbContext.Certificate.AddAsync(entity);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(Certificate entity)
        {
            _appDbContext.Certificate.Remove(entity);

            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<Certificate> GetAll()
        {
            return _appDbContext.Certificate;
        }

        public int GetMaxId()
        {
            return _appDbContext.Certificate.Max(x => x.Id);
        }

        public async Task<Certificate> Update(Certificate entity)
        {
            _appDbContext.Certificate.Update(entity);

            await _appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
