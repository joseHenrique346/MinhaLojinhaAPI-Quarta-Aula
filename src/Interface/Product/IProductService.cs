using MinhaLojinha.src.DTOs;

namespace MinhaLojinha.src.Interface;

public interface IProductService
{
    public List<ProductResponseDTO> GetAll();
    public ProductResponseDTO Create(CreateProductDTO input);
    public ProductResponseDTO Update(UpdateProductDTO input);
}