using Microsoft.AspNetCore.Mvc;
using MinhaLojinha.src.DTOs;
using MinhaLojinha.src.Interface;

namespace MinhaLojinha.src.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("All")]
    public ActionResult<List<CategoryResponseDTO>> GetAll()
    {
        // O Service já devolve a lista de DTOs pronta!
        return Ok(_categoryService.GetAll());
    }

    [HttpPost("Create")]
    public ActionResult<CategoryResponseDTO> Create([FromBody] CreateCategoryDTO input)
    {
        try
        {
            // A Controller repassa o DTO de entrada e recebe o DTO de resposta
            var newCategory = _categoryService.Create(input);
            return Ok(newCategory);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpPut("Update")]
    public ActionResult<CategoryResponseDTO> Update([FromBody] UpdateCategoryDTO input)
    {
        try
        {
            var updatedCategory = _categoryService.Update(input);
            return Ok(updatedCategory);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
}