using MinhaLojinha.src.DTOs;
using MinhaLojinha.src.Interface;
using MinhaLojinha.src.Models;

namespace MinhaLojinha.src.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public List<CategoryResponseDTO> GetAll()
    {
        var listCategories = _categoryRepository.GetAll();
        // Converte a lista de entidades para lista de DTOs usando nosso implicit operator
        return listCategories.Select(c => (CategoryResponseDTO)c).ToList();
    }

    public CategoryResponseDTO Create(CreateCategoryDTO input)
    {
        // 1. Valida pelo DTO
        if (input == null || string.IsNullOrWhiteSpace(input.Name))
            throw new ArgumentException("O nome da categoria precisa ser informado.");

        // 2. Instancia a Entidade de Domínio
        var categoryToSave = new Category
        {
            Name = input.Name
        };

        // 3. Salva no banco e devolve convertendo pra DTO!
        var savedCategory = _categoryRepository.Create(categoryToSave);
        return savedCategory; 
    }

    public CategoryResponseDTO Update(UpdateCategoryDTO input)
    {
        if (input == null || string.IsNullOrWhiteSpace(input.Name))
            throw new ArgumentException("O nome da categoria precisa ser informado.");

        var categoryToUpdate = _categoryRepository.GetById(input.Id);

        if (categoryToUpdate == null)
            throw new ArgumentException("A categoria informada não existe no banco de dados.");

        // Atualiza a entidade existente com os dados do DTO
        categoryToUpdate.Name = input.Name;

        var updatedCategory = _categoryRepository.Update(categoryToUpdate);
        return updatedCategory; 
    }
}