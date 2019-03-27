using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idealize.VO
{
    public class GrupoPermissao
    {
        [Required]
        [Display(Name = "Grupo de Acesso")]
        public int idGrupo { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}
