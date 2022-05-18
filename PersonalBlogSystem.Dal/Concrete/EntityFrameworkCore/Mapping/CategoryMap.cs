using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PersonalBlogSystem.Dal.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;
using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.Dal.Concrete.EntityFrameworkCore.Mapping;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.EntityBaseMap();

        builder.Property(x=>x.Name).IsRequired(); 
        
        builder.HasOne(x => x.Parent)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.ParentId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
