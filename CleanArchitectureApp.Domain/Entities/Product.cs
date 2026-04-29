namespace CleanArchitectureApp.Domain.Entities;

// En Product är något som säljs eller hanteras i systemet
public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    // Foreign Key (kopplar till Category)
    public int CategoryId { get; set; }

    // Navigation property
    public Category Category { get; set; } = null!;
}