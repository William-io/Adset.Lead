using Adset.Lead.Domain.Automobiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Adset.Lead.Infrastructure.Settings;

internal sealed class AutomobileSetting : IEntityTypeConfiguration<Automobile>
{
    public void Configure(EntityTypeBuilder<Automobile> builder)
    {
        builder.ToTable("Automobiles");
        
        builder.HasKey(automobile => automobile.Id);
        
        // Configuração das propriedades básicas
        builder.Property(a => a.Brand)
            .IsRequired()
            .HasMaxLength(100);
            
        builder.Property(a => a.Model)
            .IsRequired()
            .HasMaxLength(100);
            
        builder.Property(a => a.Year)
            .IsRequired();
            
        builder.Property(a => a.Plate)
            .IsRequired()
            .HasMaxLength(10);
            
        builder.Property(a => a.Km)
            .IsRequired(false);
            
        builder.Property(a => a.Color)
            .IsRequired()
            .HasMaxLength(50);
            
        builder.Property(a => a.Price)
            .IsRequired()
            .HasPrecision(18, 2);

        // Configuração para List<OptionalFeatures> - usando conversão JSON
        builder.Property(a => a.Features)
            .HasConversion(
                features => JsonSerializer.Serialize(features, (JsonSerializerOptions?)null),
                json => JsonSerializer.Deserialize<List<OptionalFeatures>>(json, (JsonSerializerOptions?)null) ?? new List<OptionalFeatures>())
            .HasColumnType("nvarchar(max)")
            .HasColumnName("Features");

        // Configuração para List<Photo> - usando conversão JSON
        builder.Property(a => a.Photos)
            .HasConversion(
                photos => JsonSerializer.Serialize(photos, (JsonSerializerOptions?)null),
                json => JsonSerializer.Deserialize<List<Photo>>(json, (JsonSerializerOptions?)null) ?? new List<Photo>())
            .HasColumnType("nvarchar(max)")
            .HasColumnName("Photos");

        // Índices para melhorar performance nas consultas
        builder.HasIndex(a => a.Brand)
            .HasDatabaseName("IX_Automobiles_Brand");
            
        builder.HasIndex(a => a.Model)
            .HasDatabaseName("IX_Automobiles_Model");
            
        builder.HasIndex(a => a.Year)
            .HasDatabaseName("IX_Automobiles_Year");
            
        builder.HasIndex(a => a.Plate)
            .HasDatabaseName("IX_Automobiles_Plate")
            .IsUnique();
            
        builder.HasIndex(a => a.Price)
            .HasDatabaseName("IX_Automobiles_Price");
            
        builder.HasIndex(a => a.Color)
            .HasDatabaseName("IX_Automobiles_Color");

        // Índice composto para busca por marca e modelo
        builder.HasIndex(a => new { a.Brand, a.Model })
            .HasDatabaseName("IX_Automobiles_Brand_Model");
    }
}