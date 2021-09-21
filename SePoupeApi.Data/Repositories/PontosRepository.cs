using Dapper;
using SePoupeApi.Data.Entities;
using SePoupeApi.Data.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SePoupeApi.Data.Repositories
{
    class PontosRepository : IPontosRepository
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

            using (var connetionString = new SqlConnection(_connectionString))
            {
                connetionString.Execute(query, pontos);
            }
        }

        public List<Pontos> Read()
        {
            var query = @"SELECT * FROM Pontos
                          ORDER BY NAME";

            using (var connection = new SqlConnection(_connectionString))
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
            using (var connetionString = new SqlConnection(_connectionString))
            {
                connetionString.Execute(query, pontos);
            }
        }

        public void Delete(Pontos pontos)
        {
            var query = @"DELETE FROM Pontos
                          WHERE IdPontos = @IdPontos";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, pontos);
            }
        }

        public Pontos getByID(int pontosID)
        {
            var query = @"SELECT * FROM Pontos
                          WHERE Pontos = @Pontos";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Pontos>(query, new { pontosID }).FirstOrDefault();
            }
        }
    }
}
