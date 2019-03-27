using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idealize.VO
{
    public class Resposta
    {
        [Required]
        [Display(Name = "Resposta")]
        public int idResposta { get; set; }

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
        [Display(Name = "Funcionário")]
        public int idFuncionario { get; set; }

        [Required]
        [Display(Name = "Opção")]
        public int idOpcao { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}
