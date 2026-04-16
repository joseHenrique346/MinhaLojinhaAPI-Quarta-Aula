namespace MinhaLojinha.src.DTOs;

public class UpdateCategoryDTO
{
    // Para atualizar, precisamos saber QUEM atualizar e o novo nome
    public long Id { get; set; }
    public string Name { get; set; }
}