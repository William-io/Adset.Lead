using Adset.Lead.Domain.Abstractions;

namespace Adset.Lead.Domain.Automobiles;

public sealed class Automobile : Entity
{
    public Automobile(
        Guid id,
        string brand,
        string model,
        int year, string plate,
        int? km,
        string color,
        decimal price,
        List<OptionalFeatures> features,
        List<Photo> photos) : base(id)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Plate = plate;
        Km = km;
        Color = color;
        Price = price;
        Features = features;
        Photos = photos;
    }

    private Automobile()
    {
        
    }

    public string Brand { get; private set; } = null!;
    public string Model { get; private set; } = null!;
    public int Year { get; private set; }
    public string Plate { get; private set; } = null!;
    public int? Km { get; private set; }
    public string Color { get; private set; } = null!;
    public decimal Price { get; private set; }

    public List<OptionalFeatures> Features { get; private set; } = new();
    public List<Photo> Photos { get; set; } = new();
}