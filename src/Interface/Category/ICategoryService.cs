using MinhaLojinha.src.DTOs;

namespace MinhaLojinha.src.Interface;

public interface ICategoryService
{
    public List<CategoryResponseDTO> GetAll();
    public CategoryResponseDTO Create(CreateCategoryDTO input);
    public CategoryResponseDTO Update(UpdateCategoryDTO input);
}