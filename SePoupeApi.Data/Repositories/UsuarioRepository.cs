using Dapper;
using SePoupeApi.Data.Entities;
using SePoupeApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeApi.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
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
                Email,
                Sexo,
                Tipo,
                Nascimento)
            VALUES(
                @Nome,
                Senha,
                @CPF,
                @Email,
                @Sexo,
                @Tipo,
                @Nascimento)";

            using (var connetionString = new MySqlConnection(_connectionString))
            {
                connetionString.Execute(query, usuario);
            }
        }
        public List<Usuario> Read()
        {
            var query = @"SELECT * FROM Usuario
                          ORDER BY nome";

            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Usuario>(query).ToList();
            }
        }

        public void Update(Usuario usuario)
        {
            var query = @" 
                UPDATE Usuario SET
                    Nome = @Nome,
                    Senha = MD5(@Senha),
                    CPF = @CPF,
                    Sexo = @Sexo,
                    Tipo = @Tipo,
                    Nascimento = @Nascimento,
                WHERE
                    IdUsuario = @IdUsuario";
            using (var connetionString = new MySqlConnection(_connectionString))
            {
                connetionString.Execute(query, usuario);
            }

        }

        public void Delete(Usuario usuario)
        {
            var query = @"DELETE FROM Usuario
                          WHERE IdUsuario = @IdUsuario";
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(query, usuario);
            }
        }

        public Usuario getByID(int usuarioID)
        {
            var query = @"SELECT * FROM Usuario
                          WHERE usuarioID = @usuarioID";

            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Usuario>(query, new { usuarioID }).FirstOrDefault();
            }
        }
        public Usuario getByEmail(string Email)
        {
            var query = @"SELECT IdUsuario FROM Usuario
                          WHERE Email = @Email";

            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Usuario>(query, new { Email }).FirstOrDefault();
            }
        }
    }
}
