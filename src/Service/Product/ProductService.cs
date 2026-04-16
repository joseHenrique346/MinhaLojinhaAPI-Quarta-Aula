using MinhaLojinha.src.DTOs;
using MinhaLojinha.src.Interface;
using MinhaLojinha.src.Models;

namespace MinhaLojinha.src.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<ProductResponseDTO> GetAll()
    {
        var listProducts = _productRepository.GetAll();
        return listProducts.Select(p => (ProductResponseDTO)p).ToList();
    }

    public ProductResponseDTO Create(CreateProductDTO input)
    {
        if (input == null || string.IsNullOrWhiteSpace(input.Name))
            throw new ArgumentException("O nome do produto precisa ser informado.");

        // Aqui protegemos a Entidade: ela só nasce depois que o DTO foi validado
        var productToSave = new Product
        {
            Name = input.Name,
            Brand = input.Brand,
            CategoryId = input.CategoryId,
            Price = input.Price,
            Stock = input.Stock
        };

        var savedProduct = _productRepository.Create(productToSave);
        return savedProduct; 
    }

    public ProductResponseDTO Update(UpdateProductDTO input)
    {
        if (input == null || string.IsNullOrWhiteSpace(input.Name))
            throw new ArgumentException("O nome do produto precisa ser informado.");

        var productToUpdate = _productRepository.GetById(input.Id);

        if (productToUpdate == null)
            throw new ArgumentException("O produto não existe no banco de dados.");

        // Modificamos apenas a entidade validada
        productToUpdate.Name = input.Name;
        productToUpdate.Brand = input.Brand;
        productToUpdate.CategoryId = input.CategoryId;

        var updatedProduct = _productRepository.Update(productToUpdate);
        return updatedProduct; 
    }
}