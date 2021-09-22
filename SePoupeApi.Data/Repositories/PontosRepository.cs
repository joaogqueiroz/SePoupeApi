using Dapper;
using MySql.Data.MySqlClient;
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
    public class PontosRepository : IPontosRepository
    {

        private readonly string _connectionString;

        public PontosRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(Pontos pontos)
        {
            var query = @"
            INSERT INTO Pontos(                
                Nivel1,
                Nivel2,
                Nivel3,
                IdUsuario)
            VALUES(
                    @Nivel1,
                    @Nivel2,
                    @Nivel3,
                    @IdUsuario)";

            using (var connetionString = new MySqlConnection(_connectionString))
            {
                connetionString.Execute(query, pontos);
            }
        }

        public List<Pontos> Read()
        {
            var query = @"SELECT * FROM Pontos";

            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Pontos>(query).ToList();
            }
        }


        public void Update(Pontos pontos)
        {
            var query = @" 
                UPDATE Pontos SET
                    Nivel1 = @Nivel1,
                    Nivel2 = @Nivel2,
                    Nivel3 = @Nivel3,                    
                WHERE
                    IdPontos = @IdPontos";
            using (var connetionString = new MySqlConnection(_connectionString))
            {
                connetionString.Execute(query, pontos);
            }
        }

        public void Delete(Pontos pontos)
        {
            var query = @"DELETE FROM Pontos
                          WHERE IdPontos = @IdPontos";
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(query, pontos);
            }
        }

        public Pontos getByID(int pontosID)
        {
            var query = @"SELECT * FROM Pontos
                          WHERE Pontos = @Pontos";

            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Pontos>(query, new { pontosID }).FirstOrDefault();
            }
        }
    }
}
