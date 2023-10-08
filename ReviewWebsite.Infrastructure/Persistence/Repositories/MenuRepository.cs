using ReviewWebsite.Application.Common.Interfaces.Persistence;
using ReviewWebsite.Domain.Menu;

namespace ReviewWebsite.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ReviewWebsiteContext _dbcontext;

        public MenuRepository(ReviewWebsiteContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Add(Menu menu)
        {
            _dbcontext.Add(menu);
            _dbcontext.SaveChangesAsync();
        }
    }
}
