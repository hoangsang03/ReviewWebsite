using Mapster;
using ReviewWebsite.Application.Menus.Commands.CreateMenu;
using ReviewWebsite.Contracts.Menus;
using ReviewWebsite.Domain.Menu;
using MenuItem = ReviewWebsite.Domain.Menu.Entities.MenuItem;
using MenuSection = ReviewWebsite.Domain.Menu.Entities.MenuSection;

namespace ReviewWebsite.Api.Common.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
                .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value));

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Items, src => src.Items);

            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);
        }
    }
}
