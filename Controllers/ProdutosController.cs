using APICatalogo.Context;
using APICatalogo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class ProdutosController : ControllerBase
  {

    private readonly APICatalogoContext _context;

    public ProdutosController(APICatalogoContext context)
    {
      _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
      var produtos = _context.Produtos?.ToList();
      if (produtos is null || produtos.Count == 0) return NoContent();
      return produtos;
    }

    [HttpGet("{id}", Name = "ObterProduto")]
    public ActionResult<Produto> GetById(int id)
    {
      var produto = _context.Produtos?.FirstOrDefault(produto => produto.Id == id);
      if(produto is null) return BadRequest();
      return produto;
    }

    [HttpPost]
    public ActionResult<Produto> Post(Produto produto)
    {
      // Persiste os dados na memoria porem n salva no banco
      _context.Produtos?.Add(produto);
      // Aqui salva no banco oq estava em memoria
      _context.SaveChanges();
      // Aqui eu retorno o produto que foi inserido a partir de uma action que eu tenho na aplicação chamada GetById
      // 1º param nome da Action
      // 2 param quais valores de rota, nesse caso o end que to chamando é o /Produtos
      // e o valor de rota que quero é o id
      // entao esse new { id = produto.Id } vai ser convertido em /Produtos/2
      // 3º param é o retorno que eu quero dar na api, nesse caso quero retornar o produto criado no banco.
      return CreatedAtAction("GetById", new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public ActionResult<Produto> Put(int id, Produto produto)
    {
      Console.WriteLine($"Info: {produto} {id}");
      if (id != produto.Id) return BadRequest();
      _context.Produtos?.Update(produto);
      _context.SaveChanges();

      return GetById(produto.Id);
    }


  }
}
