using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idealize.VO
{
    public class Funcionario
    {
        [Required]
        [Display(Name = "Funcionário")]
        public int idFuncionario { get; set; }

        [Required]
        [Display(Name = "Login")]
        [MinLength(1)]
        [MaxLength(25)]
        public string login { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [MaxLength(100)]
        public string nome { get; set; }

        [Required]
        [Display(Name = "CPF")]
        [MinLength(11)]
        [MaxLength(11)]
        [RegularExpression("^[0-9]*$")]
        public string cpf { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [MinLength(6)]
        [MaxLength(8)]
        public string senha { get; set; }

        [Required]
        [Display(Name = "Quantidade de logins inválidos.")]
        public int loginSemSucesso { get; set; }

        [Required]
        [Display(Name = "Grupo de Acesso")]
        public int idGrupo { get; set; }
    }
}
