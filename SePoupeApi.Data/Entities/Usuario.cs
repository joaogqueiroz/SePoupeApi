using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeApi.Data.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Tipo { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
