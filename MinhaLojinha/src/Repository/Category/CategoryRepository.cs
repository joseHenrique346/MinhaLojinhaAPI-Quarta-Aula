using Microsoft.EntityFrameworkCore;
using MinhaLojinha.src.Models.Data;
using MinhaLojinha.src.Interface;
using MinhaLojinha.src.Models;

namespace MinhaLojinha.src.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;

    public CategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Category> GetAll()
    {
        return _dbContext.Categories.Include(x => x.ListProduct).ToList();
    }

    public Category GetById(long id)
    {
        return _dbContext.Categories.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    public Category Create(Category category)
    {
        _dbContext.Add(category);
        _dbContext.SaveChanges();
        return category;
    }

    public Category Update(Category category)
    {
        _dbContext.Update(category);
        _dbContext.SaveChanges();
        return category;
    }
}