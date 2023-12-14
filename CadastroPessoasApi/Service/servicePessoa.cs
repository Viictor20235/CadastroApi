using CadastroPessoasApi.Data;
using CadastroPessoasApi.viewModel;

namespace CadastroPessoasApi.Service
{
    public class servicePessoa
    {
        public IEnumerable<PessoaviewModel> getall()

        {
            var repository = new Repository();
             return repository.GETALL().ToList();
        }
        public PessoaviewModel GetById(int pessoaid)

        {
            var repository = new Repository();
            return repository.GetById(pessoaid);
        }
         public PessoaviewModel GetByIdprimeiroNome(string primeiroNome) 
         {
              var repository = new Repository();
            return repository.GetByIdprimeiroNome(primeiroNome);

         }
        public void update(int pessoaId, string primeiroNome)
        {
            var repository = new Repository();
            repository.update(pessoaId, primeiroNome);
        }

        public string create(PessoaviewModel pessoa)

        {
            if (pessoa == null)
                return "os dados são obrigatorios";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.nomeMeio))
                return "o campo nomeMeio e obrigatorio";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.ultimoNome))
                return "o campo nomeMeio e obrigatorio";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.CPF))
                return "o campo nomeMeio e obrigatorio";
            var repository = new Repository();
            return repository.Create(pessoa);





        }


               


        

        
        

    }
} 
        
        


