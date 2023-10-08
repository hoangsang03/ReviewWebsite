using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewWebsite.Domain.Host.ValueObjects;
using ReviewWebsite.Domain.Menu;
using ReviewWebsite.Domain.Menu.Entities;
using ReviewWebsite.Domain.Menu.ValueObjects;

namespace ReviewWebsite.Infrastructure.Persistence.Configuarations
{
    public class MenuConfiguarations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);
            ConfigureMenuSectionsTable(builder);
            ConfigureDinnerIdsTable(builder);
            ConfigureMenuReviewIdsTable(builder);
        }

        private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.MenuReviewIds, mrb =>
            {
                mrb.ToTable("MenuReviewIds");

                mrb.WithOwner().HasForeignKey("MenuId");

                mrb.HasKey("Id");

                mrb.Property(d => d.Value)
                .HasColumnName("MenuReviewId")
                .ValueGeneratedNever();

            });

            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.DinnerIds, dib =>
            {
                dib.ToTable("DinnerIds");

                dib.WithOwner().HasForeignKey("MenuId");

                dib.HasKey("Id");

                dib.Property(d => d.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();

            });

            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.Sections, sb =>
            {
                sb.ToTable("MenuSections");

                sb.WithOwner().HasForeignKey("MenuId");

                sb.HasKey("Id", "MenuId"); // note it, at 30:35

                sb.Property(s => s.Id)
                .HasColumnName("MenuSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value));

                sb.Property(s => s.Name)
                .HasMaxLength(100);

                sb.Property(s => s.Description)
                .HasMaxLength(100);

                sb.OwnsMany(s => s.Items, ib =>
                {
                    ib.ToTable("MenuItems");

                    ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                    ib.HasKey(nameof(MenuItem.Id), "MenuId", "MenuSectionId");

                    ib.Property(s => s.Id)
                    .HasColumnName("MenuItemId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value));

                    ib.Property(s => s.Name)
                      .HasMaxLength(100);
                    ib.Property(s => s.Description)
                      .HasMaxLength(100);
                });
                sb.Navigation(s => s.Items).Metadata.SetField("_items");
                sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
            });
            builder.Metadata.FindNavigation(nameof(Menu.Sections))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

            builder.Property<string>(x => x.Name)
                .HasMaxLength(100);

            builder.Property<string>(x => x.Description)
                .HasMaxLength(100);

            builder.OwnsOne(m => m.AverageRating);

            builder.Property(x => x.HostId)
                .HasConversion(
                    id => id.Value,
                    Value => HostId.Create(Value));
        }
    }
}
