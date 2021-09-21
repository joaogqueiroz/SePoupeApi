using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeApi.Data.Entities
{
    public class Pontos
    {
        public int IdPontos { get; set; }
        public int Nivel1 { get; set; }
        public int Nivel2 { get; set; }
        public int Nivel3 { get; set; }
        public int IdUsuario { get; set; }
        //Have one
        public Usuario Usuario { get; set; }
    }
}
