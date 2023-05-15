using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configurations
{
    public class TaxRateConfiguration : IEntityTypeConfiguration<TaxRate>
    {
        public void Configure(EntityTypeBuilder<TaxRate> builder)
        {
            builder.HasData(
                new TaxRate
                {
                    Id = 1,
                    From = 0,
                    To = 8350,
                    Rate = 10.0 / 100.0,
                    FlatValue = 0,
                    isFlate = false,
                    CalculationTypeId = 1,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                 new TaxRate
                 {
                     Id = 2,
                     From = 8351,
                     To = 33950,
                     Rate = 15.0 / 100.0,
                     FlatValue = 0,
                     isFlate = false,
                     CalculationTypeId = 1,
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 },
                  new TaxRate
                  {
                      Id = 3,
                      From = 33951,
                      To = 82250,
                      Rate = 25.0 / 100.0,
                      FlatValue = 0,
                      isFlate = false,
                      CalculationTypeId = 1,
                      DateCreated = DateTime.Now,
                      DateModified = DateTime.Now
                  },
                   new TaxRate
                   {
                       Id = 4,
                       From = 82251,
                       To = 171550,
                       Rate = 28.0 / 100.0,
                       FlatValue = 0,
                       isFlate = false,
                       CalculationTypeId = 1,
                       DateCreated = DateTime.Now,
                       DateModified = DateTime.Now
                   },
                   new TaxRate
                   {
                       Id = 5,
                       From = 171551,
                       To = 372950,
                       Rate = 33.0 / 100.0,
                       FlatValue = 0,
                       isFlate = false,
                       CalculationTypeId = 1,
                       DateCreated = DateTime.Now,
                       DateModified = DateTime.Now
                   },
                   new TaxRate
                   {
                       Id = 6,
                       From = 372951,
                       To = double.MaxValue,
                       Rate = 35.0 / 100.0,
                       FlatValue = 0,
                       isFlate = false,
                       CalculationTypeId = 1,
                       DateCreated = DateTime.Now,
                       DateModified = DateTime.Now
                   },
                   new TaxRate
                   {
                       Id = 7,
                       From = 200000,
                       To = double.MaxValue,
                       Rate = 0,
                       FlatValue = 10000,
                       isFlate = true,
                       CalculationTypeId = 2,
                       DateCreated = DateTime.Now,
                       DateModified = DateTime.Now
                   },
                   new TaxRate
                   {
                       Id = 8,
                       From = 0,
                       To = 200000 - 1,
                       Rate = 5.0 / 100.0,
                       FlatValue = 0,
                       isFlate = true,
                       CalculationTypeId = 2,
                       DateCreated = DateTime.Now,
                       DateModified = DateTime.Now
                   },
                   new TaxRate
                   {
                       Id = 9,
                       From = 0,
                       To = 0,
                       Rate = 17.5 / 100,
                       FlatValue = 0,
                       isFlate = true,
                       CalculationTypeId = 3,
                       DateCreated = DateTime.Now,
                       DateModified = DateTime.Now
                   }
            );

            builder.Property(q => q.From)
                .IsRequired();
            builder.Property(q => q.To)
                .IsRequired();
            builder.Property(q => q.Rate)
                .IsRequired();
            builder.Property(q => q.FlatValue)
                .IsRequired();
            builder.Property(q => q.Id)
              .ValueGeneratedOnAdd();
            builder.HasKey(q => q.Id);
            builder.HasOne(q => q.CalculationType).WithMany(q => q.Rates);

        }
    }
}

