using SePoupeApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeApi.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        void Create(Usuario usuario);
        List<Usuario> Read();
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
        Usuario getByID(int usuarioID);
        Usuario getByEmail(string Email);
    }
}
