using Arch_lab.Models.DAL.Interfaces;

namespace Arch_lab.Models.DAL.Repositories
{
    public class EmailRepository : IBaseRepository<Email>
    {
        private readonly AppDbContext _appDbContext;

        public EmailRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(Email entity)
        {
            await _appDbContext.Email.AddAsync(entity);

            await _appDbContext.SaveChangesAsync();  
        }

        public async Task Delete(Email entity)
        {
            _appDbContext.Email.Remove(entity);

            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<Email> GetAll()
        {
            return _appDbContext.Email;
        }

        public int GetMaxId()
        {
            return _appDbContext.Email.Max(x => x.Id);

        }

        public async Task<Email> Update(Email entity)
        {
            _appDbContext.Email.Update(entity);
            
            await _appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
