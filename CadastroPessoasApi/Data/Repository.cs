using CadastroPessoasApi.Service;
using CadastroPessoasApi.viewModel;
using Dapper;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace CadastroPessoasApi.Data
{
    public class Repository
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=CADASTRODEPESSOAS;Trusted_Connection=True;MultipleActiveResultSets=True;";


        public IEnumerable<PessoaviewModel> GETALL()
        {
            string query = "SELECT TOP 1000 * FROM PESSOAS";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.Query<PessoaviewModel>(query);

            }
        }
        public PessoaviewModel GetById(int pessoaid)

        {
            string query = "SELECT * FROM PESSOAS WHERE pessoaId = @pessoaId";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                return conn.QueryFirstOrDefault<PessoaviewModel>(query, new { pessoaid });
            }
        }

        public PessoaviewModel GetByIdprimeiroNome(string primeiroNome)

        {
            string query = "SELECT * FROM PESSOAS WHERE primeiroNome = @primeiroNome";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                return conn.QueryFirstOrDefault<PessoaviewModel>(query, new { primeiroNome });
            }
        }
        public void update(int pessoaId, string primeiroNome)
        {
            var service = new servicePessoa();
            service.update(pessoaId, primeiroNome);
        }
        public string Create(PessoaviewModel pessoas)
        {
            try
            {
                string query = @"
               INSERT INTO PESSOAS(primeiroNome,nomeMeio,ultimoNome,CPF)
               VALUES(@primeiroNome,@nomeMeio,@ultimoNome,@CPF)
             ";

                using (SqlConnection con = new SqlConnection(conexao))
                {
                    con.Execute(query, new
                    {
                        primeiroNome = pessoas.primeiroNome,
                        nomeMeio = pessoas.nomeMeio,
                        CPF = pessoas.CPF,
                        ultimoNome = pessoas.ultimoNome,
                    });
                }

                return null;


            }

            catch (Exception ex)
            {
                throw ex;

            }



        }
    }
}
