namespace CleanArchitectureApp.Domain.Entities;

// Detta är en "Entity" = ett affärsobjekt
public class Category
{
    // Primärnyckel i databasen
    public int Id { get; set; }

    // Namn på kategorin (t.ex. "Electronics")
    public string Name { get; set; } = string.Empty;

    // Navigation property
    // En kategori kan ha många produkter
    public List<Product> Products { get; set; } = new();
}