using Microsoft.AspNetCore.Mvc;
using MinhaLojinha.src.Models;

namespace MinhaLojinha.src.Interface;

public interface IProductRepository
{
    public List<Product> GetAll();
    public Product Create(Product product);
    public Product Update(Product product);
    public Product GetById(long id);
}