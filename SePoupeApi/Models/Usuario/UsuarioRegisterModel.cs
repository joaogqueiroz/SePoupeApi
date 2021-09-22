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

        [Required(ErrorMessage = "Por favor, informe o nome do usuario")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha do usuario")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Por favor, informe o cpf do usuario")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Por favor, informe o email do usuario")]
        public string Email { get; set; }
        public SexoUsuario? Sexo { get; set; }
        public int Tipo { get; set; }
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
