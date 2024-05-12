using Cursinho.Model.Autor;
using Cursinho.Model.Response.Administrador;
using Cursinho.ViewModel.Administrador;
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
            // resposta formatada
            var resposta = new ResponseAdministrador<AdministradorResponseViewModel>();

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

                _repository.Add(adm); // adicao ao bd


            // Formatando msg de resposta
            var admResponse = new AdministradorResponseViewModel(
                administrador.nome,
                administrador.email,
                administrador.cargo,
                dataCadastroUTC
                ); ;

            resposta.Dados = admResponse;
            resposta.Status = status;
            resposta.Mensagem = "Dados Adicionados com Sucesso";
                

            return Ok(resposta); // retorna resposta com status 200
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resposta = new ResponseAdministrador<List<AdministradorResponseViewModel>>();

            var administradores = await _repository.Get();

            var respostaFormatada = new List<AdministradorResponseViewModel>();


            foreach (var adm in administradores)
            {
                var admFormatado = new AdministradorResponseViewModel
                {
                    nome = adm.nome,
                    email = adm.email,
                    cargo = adm.cargo,
                    data_cadastro = adm.data_cadastro
                };

                respostaFormatada.Add(admFormatado);

            }

            resposta.Dados = respostaFormatada;
            resposta.Status = true;
            resposta.Mensagem = "Dados recuperados com sucesso";
            return Ok(resposta); 
        }


        [HttpGet]
        [Route("administrador/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var resposta = new ResponseAdministrador<AdministradorResponseViewModel>();


            var administrador = await _repository.GetAdministrador(id);

            var admResponse = new AdministradorResponseViewModel(
                administrador.nome,
                administrador.email,
                administrador.cargo,
                administrador.data_cadastro
                ); ;

            resposta.Dados = admResponse;
            resposta.Status = (bool)administrador.status;
            resposta.Mensagem = "Requisição feita com Sucesso";

            return Ok(resposta);
        }

    }
}
