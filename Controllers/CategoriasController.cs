using APICatalogo.Context;
using APICatalogo.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class CategoriasController : ControllerBase
  {
    private readonly APICatalogoContext _context;

    public CategoriasController(APICatalogoContext context)
    {
      _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
      var categorias = _context.Categorias?.ToList();
      if (categorias is null || categorias.Count == 0) return Array.Empty<Categoria>();
      return categorias;
    }

    [HttpGet("produtos")]
    public ActionResult<IEnumerable<Categoria>> GetCategoriaProdutos()
    {
      return _context.Categorias?.Include(p => p.Produtos).ToList();
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> GetById(int id)
    {
      var categoria = _context.Categorias?.FirstOrDefault(categoria => categoria.Id == id);
      if (categoria is null) return NotFound("Categoria nao encontrada");
      return categoria;
    }

    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
      if (categoria is null) return BadRequest();

      _context.Categorias?.Add(categoria);
      _context.SaveChanges();

      return CreatedAtRoute("ObterCategoria", new { id = categoria.Id }, categoria);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
      if (id != categoria.Id) return BadRequest();

      _context.Entry(categoria).State = EntityState.Modified;
      _context.SaveChanges();

      return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
      var categoria = _context.Categorias?.FirstOrDefault(categoria => categoria.Id == id);
      if (categoria is null) return NotFound();
      _context.Categorias?.Remove(categoria);
      _context.SaveChanges();
      return Ok(categoria);
    }
  }
}
