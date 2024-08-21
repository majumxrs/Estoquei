using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoquei.Models
{
    [Table("EntradaeSaida")]
    public class EntradaeSaida
    {

        [Column("Id")]
        [Display(Name = "Cod. da Enr=trada e Saida")]
        public int Id { get; set; }

        [ForeignKey("ProdutoId")]
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }
        public Produto? Produto{ get; set; }


        [Column("QuantidadeMovimentacao")]
        [Display(Name ="Quantideda de Movimentações")]
        public int QuantidadeMovimentacao { get; set; }

        [ForeignKey("TipoMovimentacaoId")]
        [Display(Name = "Tipo de Movimentação")]
        public int TipoMovimentacaoId { get; set; }
        public TipoMovimentacao? TipoMovimentacao { get; set; }

        [Column("DataMovimentacao")]
        [Display(Name = "Data")]
        public DateTime DataMovimentacao { get; set; }
    }
}
