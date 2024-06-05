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
    [Route("api/v1/Administrador")]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorRepository _repository;

        public AdministradorController(IAdministradorRepository repository)
        {
            _repository = repository;
        }


        // Adição de Administrador
        [HttpPost]
        [Route("AdicionarAdministrador")]
        public async Task<IActionResult> Add(AdministradorCreateDTO administrador)
        {
            
            // adicao ao bd
            var resposta = await _repository.Add(administrador);

           if(resposta.Mensagem == "Erro no sistema usuário não adicionado")
           {
                return BadRequest(resposta.Mensagem);
           }


            // retorno 200 com a resposta estruturada
            return Ok(resposta); 
        }


        // Lista de Administradores
        [HttpGet]
        [Route("ListarAdministradores/")]
        public async Task<IActionResult> Get()
        {
           
            // dados com todos administradores
            var resposta = await _repository.Get();

            // retornando status 200 com resposta formatada
            return Ok(resposta); 
        }

        // Administrador via Id
        [HttpGet]
        [Route("BuscarAdministrador/{id}")]
        public async Task<IActionResult> Get(int id)
        {
           
            // fazendo busca pelo id
            var resposta = await _repository.GetAdministrador(id);

            // retorno 200 com a resposta estruturada
            return Ok(resposta);
        }

        // Desabilitando Administrador
        [HttpPatch]
        [Route("DesabilitarAdministrador/{id}")]
        public async Task<IActionResult> Disable(int id)
        {
            
            // fazendo a desativação o user
            var resposta = await _repository.Disable(id);

            return Ok(resposta);
        }

        // Habilitando Administrador
        [HttpPatch]
        [Route("HabilitarAdministrador/{id}")]
        public async Task<IActionResult> Enable(int id)
        {

            // fazendo ativação o user
            var resposta = await _repository.Enable(id);

            return Ok(resposta);
        }

        // Deletando Administrador
        [HttpDelete]
        [Route("DeletarAdministrador/{id}")]
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
