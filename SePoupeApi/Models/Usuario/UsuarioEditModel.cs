using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeApi.Services.Models.Usuario
{
    public class UsuarioEditModel
    {
        [Required]
        public int IdUsuario { get; set; }
        public int Nome { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public SexoUsuario? Sexo { get; set; }
        public TipoUsuario? Tipo { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
