using Cursinho.Dto.Administrador;
using Cursinho.Infraestrutura;
using Cursinho.Model.Autor;
using Cursinho.Model.Response.Administrador;
using Cursinho.ViewModel.Administrador;
using Microsoft.AspNetCore.Http.HttpResults;
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


        // Adição de Administrador
        //Obs criar um DTO pasta DTO > pasta Administrador > classe AdmiministradorCriacaoDTO
        // essa classe será o parametro de entrada
        [HttpPost]
        public async Task<IActionResult> Add(AdministradorViewModel administrador)
        {
            // resposta formatada
            var resposta = new ResponseAdministrador<AdministradorResponseViewModel>();

                var status = true; // todo cadastro o status se inicia com true

                // Data de Cadastro
                DateTime dataCadastro = DateTime.Today;
                DateTime dataCadastroUTC = dataCadastro.ToUniversalTime();

               // criando obj para adicionar no bd
                var adm = new Administrador(
                     administrador.nome,
                     administrador.email,
                     administrador.senha,
                     administrador.cargo,
                     status,
                     dataCadastroUTC
                     );

            // adicao ao bd
            _repository.Add(adm);


            // buscando usuário adicionando para se pegar id do user
            var admEncontrado =  await _repository.FindByName(administrador.nome);

            // Formatando msg de resposta
            var admResponse = new AdministradorResponseViewModel(
                admEncontrado.id, // id de user adicionado
                administrador.nome,
                administrador.email,
                administrador.cargo,
                dataCadastroUTC
                ); ;

            // resposta estrutura
            resposta.Dados = admResponse;
            resposta.Status = status;
            resposta.Mensagem = "Dados Adicionados com Sucesso";

            // retorno 200 com a resposta estruturada
            return Ok(resposta); 
        }


        // Lista de Administradores
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // resposta formatada
            var resposta = new ResponseAdministradorList<List<AdministradorResponseViewModel>>();

            // dados com todos administradores
            var administradores = await _repository.Get();

            
            // objeto com Lista de objetos tipo AdministradorResponseViewModel
            var listaAdms = new List<AdministradorResponseViewModel>();

            // adicionando todos os adms na lista de objetos respostaFormatada
            foreach (var adm in administradores)
            {
                if (adm.status == true)
                {
                    var admFormatado = new AdministradorResponseViewModel
                    {
                        id = adm.id,
                        nome = adm.nome,
                        email = adm.email,
                        cargo = adm.cargo,
                        data_cadastro = adm.data_cadastro
                    };

                    listaAdms.Add(admFormatado);
                }
            }

            // resposta estrutura
            resposta.Dados = listaAdms;
            resposta.Mensagem = "Dados recuperados com sucesso";

            // retornando status 200 com resposta formatada
            return Ok(resposta); 
        }

        // Administrador via Id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // instanciando objeto com estrutura da resposta
            var resposta = new ResponseAdministrador<AdministradorResponseViewModel>();

            // fazendo busca pelo id
            var administrador = await _repository.GetAdministrador(id);

            // Verificação se status de user for false 
            if(administrador.status is false)
            {
                return NotFound("Usuário não encontrado");
            }

            // objeto com o a resposta da busa pelo id estruturado
            var admResponse = new AdministradorResponseViewModel(
                administrador.id,
                administrador.nome,
                administrador.email,
                administrador.cargo,
                administrador.data_cadastro
                ); 

            // resposta estrutura
            resposta.Dados = admResponse;
            resposta.Status = (bool)administrador.status;
            resposta.Mensagem = "Requisição feita com Sucesso";

            // retorno 200 com a resposta estruturada
            return Ok(resposta);
        }

        // Desabilitando Administrador
        [HttpPatch]
        [Route("disable/{id}")]
        public async Task<IActionResult> Disable(int id)
        {
            
            // fazendo a desativação o user
            var resposta = await _repository.Disable(id);

            return Ok(resposta);
        }

        // Habilitando Administrador
        [HttpPatch]
        [Route("enable/{id}")]
        public async Task<IActionResult> Enable(int id)
        {

            // fazendo ativação o user
            var resposta = await _repository.Enable(id);

            return Ok(resposta);
        }

        // Deletando Administrador
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            // deletando user
            var resposta =  await _repository.Delete(id);

            return Ok(resposta);
        }


        // Update Administrador
        [HttpPatch("AtualizarAdministrador")]      
        public async Task<IActionResult> Update(AdministradorUpdateDTO administrador)
        {
            var dados = await _repository.Update(administrador);

           
            if (dados.Mensagem == "Id do usuário é necessário")
            {
                return BadRequest("Id do usuário é necessário");
            }

            if (dados.Mensagem == "Usuário não encontrado")
            {
                return BadRequest("Usuário não encontrado");
            }


            return Ok(dados);
        }
    }
}
