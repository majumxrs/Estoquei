using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Estoquei.Models
{
    [Table("TipoProduto")]
    public class TipoProduto
    {
        [Column("Id")]
        [Display(Name = "Cod. do Tipo do Produto")]
        public int Id { get; set; }

        [Column("NomeTipoProduto")]
        [Display(Name = "Nome")]
        public string NomeTipoProduto { get; set; } = string.Empty;
    }
}
