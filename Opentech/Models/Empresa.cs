using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opentech.Models
{
    [Table("Empresas")]
    public class Empresa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da empresa é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        public string Site { get; set; }

        [Required(ErrorMessage = "A quantidade de funcionários é obrigatória", AllowEmptyStrings = false)]
        [DisplayFormat(DataFormatString = "{0:D}", ApplyFormatInEditMode = true)]
        public int QuantidadeFuncionarios { get; set; }
    }
}