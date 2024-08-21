using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoquei.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("Id")]
        [Display(Name = "Cod. do Produto")]
        public int Id { get; set; }

        [Column("NomeProduto")]
        [Display(Name ="Nome")]
        public string NomeProduto { get; set; } = string.Empty;

        [Column("PesoProduto")]
        [Display(Name ="Peso")]
        public int PesoProduto { get; set; }

        [Column("QuantidadeEstoque")]
        [Display(Name = "Quatidade no Estoque")]
        public int QuantidadeEstoque { get; set; }

        [Column("StatusProduto")]
        [Display(Name = "Status do Produto")]
        public bool StatusProduto { get; set; }

        [ForeignKey("TipoProdutoId")]
        [Display(Name = "Tipo")]
        public int TipoProdutoId { get; set; }
        public TipoProduto? TipoProduto { get; set; }

    }
}
