using Cursinho.Model.Autor;
using Cursinho.Model.Response.Administrador;
using Cursinho.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Cursinho.Controllers
{
    [ApiController]
    [Route("api/v1/administrador")]
    public class AdministradorController : ControllerBase
    {

        private readonly IAdministradorRepository _repository;

        public AdministradorController(IAdministradorRepository repository)
        {
            _repository = repository;
        }



        [HttpPost]
        public async Task<IActionResult> Add(AdministradorViewModel administrador)
        {
            ResponseAdministrador<Administrador> resposta = new ResponseAdministrador<Administrador>();

                var status = true; // todo cadastro o status se inicia com true

                // Data de Cadastro
                DateTime dataCadastro = DateTime.Today;
                DateTime dataCadastroUTC = dataCadastro.ToUniversalTime();


                var adm = new Administrador(
                     administrador.nome,
                     administrador.email,
                     administrador.senha,
                     administrador.cargo,
                     status,
                     dataCadastroUTC
                     );

                _repository.Add(adm);


            Administrador admResponse = new Administrador(
                administrador.nome,
                administrador.email,
                administrador.cargo    
                ); ;



            resposta.Dados = admResponse;
            resposta.Status = status;
            resposta.Mensagem = "Dados Adicionados com Sucesso";
                

            return Ok(resposta); 
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var administradores = await _repository.Get();

            return Ok(administradores); 
        }


        [HttpGet]
        [Route("administrador/{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var administrador = await _repository.GetAdministrador(id);

            return Ok(administrador);
        }

    }
}
