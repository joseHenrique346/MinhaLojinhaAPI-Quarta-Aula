using Microsoft.EntityFrameworkCore;
using MinhaLojinha.src.Interface;
using MinhaLojinha.src.Models;
using MinhaLojinha.src.Models.Data;

namespace MinhaLojinha.src.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Product> GetAll()
    {
        List<Product> listProduct = _dbContext.Products.Include(x => x.Category).ToList();
        return listProduct;
    }

    public Product Create(Product product)
    {
        _dbContext.Add(product);
        _dbContext.SaveChanges();
        return product;
    }

    public Product Update(Product product)
    {
        _dbContext.Update(product);
        _dbContext.SaveChanges();
        return product;
    }

    public Product GetById(long id)
    {
        Product searchedProduct = _dbContext.Products.Include(x => x.Category).AsNoTracking().FirstOrDefault(x => x.Id == id);
        return searchedProduct;
    }
}