namespace MinhaLojinha.src.DTOs;

public class UpdateProductDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? Brand { get; set; }
    public long CategoryId { get; set; }
}