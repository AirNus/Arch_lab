using Arch_lab.Models.DAL.Interfaces;

namespace Arch_lab.Models.DAL.Repositories
{
    public class ClientRepository : IBaseRepository<Client>
    {
        private readonly AppDbContext _appDbContext;

        public ClientRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(Client entity)
        {
            await _appDbContext.Client.AddAsync(entity);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(Client entity)
        {
            _appDbContext.Client.Remove(entity);

            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<Client> GetAll()
        {
            return _appDbContext.Client;
        }

        public int GetMaxId()
        {
            return _appDbContext.Client.Max(x => x.Id);
        }

        public async Task<Client> Update(Client entity)
        {
            _appDbContext.Client.Update(entity);

            await _appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
