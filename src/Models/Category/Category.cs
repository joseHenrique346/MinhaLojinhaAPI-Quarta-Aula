using System.Text.Json.Serialization;

namespace MinhaLojinha.src.Models;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<Product> ListProduct { get; set; } = new List<Product>();

    public Category() { }

    public Category(long id, string name, List<Product> listProduct)
    {
        Id = id;
        Name = name;
        ListProduct = listProduct;
    }
}