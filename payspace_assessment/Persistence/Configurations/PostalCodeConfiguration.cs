using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configurations
{
    public class PostalCodeConfiguration : IEntityTypeConfiguration<PostalCode>
    {
        public void Configure(EntityTypeBuilder<PostalCode> builder)
        {
            builder.HasData(
                new PostalCode
                {
                    Id = 1,
                    Code = "7441",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                 new PostalCode
                 {
                     Id = 2,
                     Code = "A100",
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 },
                  new PostalCode
                  {
                      Id = 3,
                      Code = "7000",
                      DateCreated = DateTime.Now,
                      DateModified = DateTime.Now
                  },
                   new PostalCode
                   {
                       Id = 4,
                       Code = "1000",
                       DateCreated = DateTime.Now,
                       DateModified = DateTime.Now
                   }
            );

            builder.Property(q => q.Code)
                .IsRequired()
                .HasMaxLength(4);
            builder.Property(q => q.Id)
              .ValueGeneratedOnAdd();
            builder.HasKey(q => q.Id);
        }
    }
}
