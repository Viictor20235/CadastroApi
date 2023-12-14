using CadastroPessoasApi.Service;
using CadastroPessoasApi.viewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet("getall")]
        public IEnumerable<PessoaviewModel> getall()
        {
            var service = new servicePessoa();
            return service.getall();
        }
        [HttpGet("GetById/{pessoaid}")]
          public PessoaviewModel GetById (int pessoaid)
        {
            var service = new servicePessoa();
            return service.GetById(pessoaid);
        }

        [HttpGet("GetByIdprimeiroNome/{primeiroNome}")]
        public PessoaviewModel GetByIdprimeiroNome (string primeiroNome)
        {
            var service = new servicePessoa();
            return service.GetByIdprimeiroNome(primeiroNome);



        }
        [HttpPut("update/{pessoaid}/{primeiroNome}")]
        
        public void update (int pessoaId, string primeiroNome)
        {
            var service = new servicePessoa();
            service.update(pessoaId, primeiroNome);
        }

        [HttpPost("create")]

        public ActionResult Create(PessoaviewModel pessoa)
        {

            var service = new servicePessoa();
            var resultado = service.create(pessoa);

            var result = new
            {
                succes = true,
                Data = "Cadastro realziado com sucesso"

            };
            return Ok(result);
            
              


        }



    }
}
