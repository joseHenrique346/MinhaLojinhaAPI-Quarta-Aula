using System.Text.Json.Serialization;

namespace MinhaLojinha.src.Models;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long? CategoryId { get; set;}
    public string? Brand { get; set; }
    [JsonIgnore]
    public Category? Category { get; set;}
    public decimal Price { get; set;}
    public int Stock { get; set;}

    public Product() { }
    
    public Product(long id, string name, long? categoryId, string? brand, decimal price, int stock)
    {
        Id = id;
        Name = name;
        CategoryId = categoryId;
        Brand = brand;
        Price = price;
        Stock = stock;
    }
}