using MinhaLojinha.src.Models;

namespace MinhaLojinha.src.DTOs;

public class CategoryResponseDTO
{
    public long Id { get; set; }
    public string Name { get; set; }

    // O nosso operador implícito para o C# converter a Entidade em DTO sozinho!
    public static implicit operator CategoryResponseDTO(Category category)
    {
        if (category == null) return null;

        return new CategoryResponseDTO
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}