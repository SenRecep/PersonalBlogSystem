using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PersonalBlogSystem.Dal.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;
using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.Dal.Concrete.EntityFrameworkCore.Mapping;

public class BlogMap : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.EntityBaseMap();

        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.Content).IsRequired();

        builder.HasOne(x=>x.Category)
            .WithMany(x=>x.Blogs)
            .HasForeignKey(x=>x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}