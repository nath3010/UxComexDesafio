using Dapper;
using System.Data;
using System.Data.SqlClient;
using UxComexDesafio.Models;

namespace UxComexDesafio.Repository
{
    public class PessoasRepository : IPessoasRepository
    {
        
        private readonly IDbConnection db;

        public PessoasRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            
        }

        public Pessoa Add(Pessoa pessoa)
        {
            using (var connection = db) 
            { 
                var sql = "INSERT INTO Pessoas (Nome, Cpf, Telefone) VALUES (@Nome, @Cpf, @Telefone);" +
                          "SELECT CAST(SCOPE_IDENTITY() as int);";

                var id = connection.Query<int>(sql, new { pessoa.Nome, pessoa.Cpf, pessoa.Telefone }).Single();
                pessoa.Pessoaid = id;

                return pessoa;
            }
        }

        public void Remove(int id)
        {
            using (var connection = db)
            {
                var sql = "DELETE FROM Pessoas WHERE Pessoaid = @Pessoaid";
                connection.Execute(sql, new { @Pessoaid = id });


            }
        }

        public Pessoa Find(int id)
        {
            using (var connection = db)
            {
                var sql = "SELECT * FROM Pessoas WHERE Pessoaid = @Pessoaid";
                return connection.Query<Pessoa>(sql, new { @Pessoaid = id }).Single();
            }
        }

        public List<Pessoa> GetAll()
        {
            using (var connection = db)
            {
                var sql = "SELECT * FROM Pessoas";
                return connection.Query<Pessoa>(sql).ToList();
            }
           
        }

        public void Update(Pessoa pessoa)
        {
            using (var connection = db)
            {
                var sql = "UPDATE Pessoas SET Nome = @Nome , Cpf = @Cpf, Telefone = @Telefone WHERE Pessoaid = @Pessoaid";
                connection.Execute(sql, new { @Nome = pessoa.Nome, @Cpf = pessoa.Cpf, @Telefone = pessoa.Telefone, @Pessoaid = pessoa.Pessoaid });
               
            }


        }

        public Pessoa GetPessoaWithEndereco(int id)
        {
            var p = new
            {
                PessoaId = id
            };

            var sql = "SELECT * FROM Pessoas WHERE Pessoaid = @Pessoaid;"
                + " SELECT * FROM Enderecos WHERE Pessoaid = @Pessoaid; ";

            Pessoa pessoa;

            using (var lists = db.QueryMultiple(sql, p))
            {
                pessoa = lists.Read<Pessoa>().ToList().FirstOrDefault();
                pessoa.Endereco = lists.Read<Endereco>().ToList();
            }

            return pessoa;
        }
    }
}
