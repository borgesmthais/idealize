using System;
using System.ComponentModel.DataAnnotations;

namespace Idealize.VO
{
    public class Campanha
    {
        [Required]
        [Display(Name = "Campanha")]
        public int idCampanha { get; set; }

        [Required]
        [Display(Name = "Funcionário")]
        public int idFuncionario { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required]
        [Display(Name = "Data Inicial")]
        public DateTime dataInicio { get; set; }

        [Required]
        [Display(Name = "DataFinal")]
        public DateTime dataFinal { get; set; }
    }
}
