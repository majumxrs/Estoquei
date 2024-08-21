using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoquei.Models
{
    [Table("TipoMOvimentacao")]
    public class TipoMovimentacao
    {
        [Column("Id")]
        [Display(Name = "Cod. do Tipo da Movimentação")]
        public int Id { get; set; }

        [Column("NomeTipoMovimentacao")]
        [Display(Name = "Nome da movimentação")]
        public string NomeTipoMovimentacao { get; set; } = string.Empty;
    }
}
