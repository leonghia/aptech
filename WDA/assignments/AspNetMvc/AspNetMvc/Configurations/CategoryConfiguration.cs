using AspNetMvc.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetMvc.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Desktop PC" },
                new Category { Id = 2, Name = "Phone" },
                new Category { Id = 3, Name = "Tablet" },
                new Category { Id = 4, Name = "Console" },
                new Category { Id = 5, Name = "Watch" },
                new Category { Id = 6, Name = "Photo/Video" },
                new Category { Id = 7, Name = "TV/Monitor" }
                );
        }
    }
}
