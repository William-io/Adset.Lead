using Adset.Lead.Domain.Automobiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adset.Lead.Infrastructure.Settings;

internal sealed class AutomobileSetting : IEntityTypeConfiguration<Automobile>
{
    public void Configure(EntityTypeBuilder<Automobile> builder)
    {
        builder.ToTable("Automobiles");
        
        builder.HasKey(automobile => automobile.Id);
        
        
        
    }
}