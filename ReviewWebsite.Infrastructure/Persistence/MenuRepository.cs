using ReviewWebsite.Application.Common.Interfaces.Persistence;
using ReviewWebsite.Domain.Menu;

namespace ReviewWebsite.Infrastructure.Persistence
{
    public class MenuRepository : IMenuRepository
    {
        private readonly List<Menu> _menus = new();
        public void Add(Menu menu)
        {
            _menus.Add(menu);
        }
    }
}
