using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeApi.Services.Models.Pontos
{
    public class PontosEditModel
    {
        public int IdPontos { get; set; }
        public int Nivel1 { get; set; }
        public int Nivel2 { get; set; }
        public int Nivel3 { get; set; }
        public int IdUsuario { get; set; }

    }
}
