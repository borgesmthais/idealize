using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idealize.VO
{
    public class TemplateQuestoes
    {
        [Required]
        [Display(Name = "Questão Template")]
        public int idTemplateQuestao { get; set; }

        [Required]
        [Display(Name = "Questionário Template")]
        public int idTemplateQuestionario { get; set; }

        [Required]
        [Display(Name = "Tipo de Questão")]
        public int idTipoQuestao { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}
