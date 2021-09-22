using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeApi.Services.Models.Usuario
{
    public class UsuarioRegisterModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        [Required]
        public string CPF { get; set; }
        public SexoUsuario? Sexo { get; set; }
        public TipoUsuario? Tipo { get; set; }
        public DateTime Nascimento { get; set; }
    }

    //Usar na MODEL
    public enum SexoUsuario
    {
        M,
        F
    }
    public enum TipoUsuario
    {
        ADM,
        USER
    }
}
