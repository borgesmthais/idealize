using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idealize.VO
{
    public class Questoes
    {
        [Required]
        [Display(Name = "Questão")]
        public int idQuestao { get; set; }

        [Required]
        [Display(Name = "Questionário")]
        public int idQuestionario { get; set; }

        [Required]
        [Display(Name = "Campanha")]
        public int idCampanha { get; set; }

        [Required]
        [Display(Name = "Tipo de Questão")]
        public int idTipoQuestao { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}
