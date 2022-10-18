using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Domain;
[Table("Categorias")]
public class Categoria
{
  // É uma boa prática inicializar uma collection
  public Categoria()
  {
    Produtos = new Collection<Produto>();
  }

  [Key]
  public int Id { get; set; }
  [Required]
  [StringLength(80)]
  public string? Nome { get; set; }
  [Required]
  [StringLength(300)]
  public string? ImagemUrl { get; set; }
  // Essa Collection mostra para o EF que uma categoria tem muitos produtos
  public ICollection<Produto> Produtos { get; set; }
}
