using Microsoft.AspNetCore.Mvc;
using MinhaLojinha.src.DTOs;
using MinhaLojinha.src.Interface;

namespace MinhaLojinha.src.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    // A Controller só conhece a Interface do Service
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("All")]
    public ActionResult<List<ProductResponseDTO>> GetAll()
    {
        var listProduct = _productService.GetAll();
        return Ok(listProduct); // Retorna 200 OK com a lista limpa e blindada
    }

    [HttpPost("Create")]
    public ActionResult<ProductResponseDTO> Create([FromBody] CreateProductDTO input)
    {
        try
        {
            // O Service recebe o DTO de entrada, cria a entidade, salva no banco
            // e o implicit operator devolve o ResponseDTO automaticamente
            var newProduct = _productService.Create(input);
            return Ok(newProduct);
        }
        catch (ArgumentException ex)
        {
            // Se o Service estourar o erro de validação, a Controller devolve um 400
            return BadRequest(new { mensagem = ex.Message });
        }
    }

    [HttpPut("Update")]
    public ActionResult<ProductResponseDTO> Update([FromBody] UpdateProductDTO input)
    {
        try
        {
            var updatedProduct = _productService.Update(input);
            return Ok(updatedProduct);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
    }
}