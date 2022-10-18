using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Domain;

[Table("Produtos")]
public class Produto
{
  [Key]
  public int Id { get; set; }
  [Required]
  [StringLength(80)]
  public string? Nome { get; set; }
  [Required]
  [StringLength(300)]
  public string? Descricao { get; set; }
  // Aqui eu digo que a coluna preco na tabela vai ser do tipo decimal com tamanho maximo de 10 digitos e 2 casas decimais.
  [Column(TypeName = "decimal(10, 2)")]
  public decimal Preco { get; set; }
  [Required]
  [StringLength(300)]
  public string? ImagemUrl { get; set; }
  public float Estoque { get; set; }
  public DateTime DataCadastro { get; set; }
  // Essas duas props fazem relacionamento com a Entidade Categoria pq 1 produto tem uma categoria
  public int CategoriaId { get; set; }
  public Categoria? Categoria { get; set; }
}
