using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idealize.VO
{
    public class TemplateOpcoes
    {
        [Required]
        [Display(Name = "Opção Template")]
        public int idTemplateOpcao { get; set; }

        [Required]
        [Display(Name = "Questão Template")]
        public int idTemplateQuestao { get; set; }

        [Required]
        [Display(Name = "Questionário Template")]
        public int idTemplateQuestionario { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}
