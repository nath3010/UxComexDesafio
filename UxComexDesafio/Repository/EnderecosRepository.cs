using System.Data.SqlClient;
using System.Data;
using UxComexDesafio.Models;
using Dapper;
using System.Runtime.ConstrainedExecution;

namespace UxComexDesafio.Repository
{
    public class EnderecosRepository : IEnderecosRepository
    {
        private readonly IDbConnection db;

        public EnderecosRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        }

        public Endereco Add(Endereco endereco)
        {
            using (var connection = db)
            {
                var sql = "INSERT INTO Enderecos (Pessoaid, EnderecoNome, Cep, Cidade, Estado) VALUES (@Pessoaid,  @EnderecoNome, @Cep, @Cidade, @Estado);";

                connection.Execute(sql, endereco);

                return endereco;
            }
        }

        public Endereco Find(int id)
        {
            using (var connection = db)
            {
                var sql = "SELECT * FROM Enderecos WHERE Enderecoid = @Enderecoid";
                return connection.Query<Endereco>(sql, new { @Enderecoid = id }).Single();
            }
        }

        public List<Endereco> GetAll()
        {
            using (var connection = db)
            {
                var sql = "SELECT * FROM Enderecos";
                return connection.Query<Endereco>(sql).ToList();
            }
        }

        public void Remove(int id)
        {
            using (var connection = db)
            {
                var sql = "DELETE FROM Enderecos WHERE Enderecoid = @Enderecoid";
                connection.Execute(sql, new { @Enderecoid = id });


            }
        }

        public Endereco Update(Endereco endereco)
        {
            using (var connection = db)
            {
                var sql = "UPDATE Enderecos SET Pessoaid = @Pessoaid, EnderecoNome = @EnderecoNome, Cep = @Cep, Cidade = @Cidade, Estado = @Estado WHERE Enderecoid = @Enderecoid";
                connection.Execute(sql, endereco);

                return endereco;
            }
        }


    }
}
