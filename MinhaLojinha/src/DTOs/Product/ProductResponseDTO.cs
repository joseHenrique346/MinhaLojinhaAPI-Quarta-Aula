using MinhaLojinha.src.Models;

namespace MinhaLojinha.src.DTOs;

public class ProductResponseDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? Brand { get; set; }
    
    // Olha a blindagem aqui: entregamos apenas o texto, não o objeto Category inteiro!
    public string CategoryName { get; set; }

    public static implicit operator ProductResponseDTO(Product product)
    {
        if (product == null) return null;

        return new ProductResponseDTO
        {
            Id = product.Id,
            Name = product.Name,
            Brand = product.Brand,
            // Valida se a Categoria veio preenchida do banco para não dar erro de nulo
            CategoryName = product.Category != null ? product.Category.Name : "Sem Categoria"
        };
    }
}