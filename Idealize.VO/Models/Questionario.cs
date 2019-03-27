using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idealize.VO
{
    public class Questionario
    {
        [Required]
        [Display(Name = "Questionário")]
        public int idQuestionario { get; set; }

        [Required]
        [Display(Name = "Campanha")]
        public int idCampanha { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string nome { get; set; }
    }
}
