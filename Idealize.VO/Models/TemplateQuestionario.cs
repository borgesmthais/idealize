using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idealize.VO
{
    public class TemplateQuestionario
    {
        [Required]
        [Display(Name = "Questionário Template")]
        public int idTemplateQuestionario { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string nome { get; set; }
    }
}
