using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configurations
{
    public class TaxCalculationTypeConfiguration : IEntityTypeConfiguration<TaxCalculationType>
    {
        public void Configure(EntityTypeBuilder<TaxCalculationType> builder)
        {
            builder.HasData(
                new TaxCalculationType
                {
                    Id = 1,
                    Type = "Progressive",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                 new TaxCalculationType
                 {
                     Id = 2,
                     Type = "Flat Value",
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 },
                 new TaxCalculationType
                 {
                     Id = 3,
                     Type = "Flat Rate",
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 }
            );

            builder.Property(q => q.Type)
                .IsRequired().HasColumnType("varchar(50)");
            builder.Property(q => q.Id)
              .ValueGeneratedOnAdd();
            builder.HasKey(q => q.Id);
            builder.HasMany(q => q.PostalCode_TaxCalculationTypes).WithOne(q => q.TaxCalculationType);
        }
    }
}
