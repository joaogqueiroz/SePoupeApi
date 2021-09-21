using Dapper;
using SePoupeApi.Data.Entities;
using SePoupeApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeApi.Data.Repositories
{
    class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(Usuario usuario)
        {
            var query = @"
            INSERT INTO Usuario(                
                Nome,
                Senha,
                CPF,
                Sexo,
                Tipo,
                Nascimento)
            VALUES(
                @Nome,
                CONVERT(VARCHAR(32), HASHBYTES('MD5', @Senha), 2),
                @CPF,
                @Sexo,
                @Tipo,
                @Nascimento)";

            using (var connetionString = new SqlConnection(_connectionString))
            {
                connetionString.Execute(query, usuario);
            }
        }
        public List<Usuario> Read()
        {
            var query = @"SELECT * FROM Usuario
                          ORDER BY NAME";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Usuario>(query).ToList();
            }
        }

        public void Update(Usuario usuario)
        {
            var query = @" 
                UPDATE Usuario SET
                    Nome = @Nome,
                    Senha = CONVERT(VARCHAR(32), HASHBYTES('MD5', @Senha), 2),
                    CPF = @CPF,
                    Sexo = @Sexo,
                    Tipo = @Tipo,
                    Nascimento = @Nascimento,
                WHERE
                    IdUsuario = @IdUsuario";
            using (var connetionString = new SqlConnection(_connectionString))
            {
                connetionString.Execute(query, usuario);
            }

        }

        public void Delete(Usuario usuario)
        {
            var query = @"DELETE FROM Usuario
                          WHERE IdUsuario = @IdUsuario";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, usuario);
            }
        }

        public Usuario getByID(int usuarioID)
        {
            var query = @"SELECT * FROM Usuario
                          WHERE usuarioID = @usuarioID";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Usuario>(query, new { usuarioID }).FirstOrDefault();
            }
        }
    }
}
