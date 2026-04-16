namespace MinhaLojinha.src.DTOs;

public class CreateProductDTO
{
    public string Name { get; set; }
    public string? Brand { get; set; }
    public long CategoryId { get; set; }
    public decimal Price { get; set;}
    public int Stock { get; set;}
}