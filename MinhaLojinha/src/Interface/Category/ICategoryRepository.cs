using MinhaLojinha.src.Models;

namespace MinhaLojinha.src.Interface;

public interface ICategoryRepository
{
    List<Category> GetAll();
    Category GetById(long id);
    Category Create(Category category);
    Category Update(Category category);
}