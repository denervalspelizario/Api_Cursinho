using Cursinho.Dto.Administrador;
using Cursinho.Model.Autor;
using Microsoft.AspNetCore.Mvc;

namespace Cursinho.Controllers
{
    [ApiController]
    [Route("apiCursinho/administracao")]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorRepository _repository;

        public AdministradorController(IAdministradorRepository repository)
        {
            _repository = repository;
        }


        // Adição de Administrador
        [HttpPost]
        [Route("adicionarAdministrador/")]
        public async Task<IActionResult> Add(AdministradorCreateDTO administrador)
        {
            
            var resposta = await _repository.Add(administrador);

            return Ok(resposta); 
        }


        // Lista de Administradores
        [HttpGet]
        [Route("listarAdministradores/")]
        public async Task<IActionResult> Get()
        {
            var resposta = await _repository.Get();

            return Ok(resposta); 
        }

        // Administrador via Id
        [HttpGet]
        [Route("buscarAdministrador/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var resposta = await _repository.GetAdministrador(id);

            return Ok(resposta);
        }

        // Desabilitando Administrador
        [HttpPatch]
        [Route("desabilitarAdministrador/{id:int}")]
        public async Task<IActionResult> Disable(int id)
        {
            
            var resposta = await _repository.Disable(id);

            return Ok(resposta);
        }

        // Habilitando Administrador
        [HttpPatch]
        [Route("habilitarAdministrador/{id:int}")]
        public async Task<IActionResult> Enable(int id)
        {
            var resposta = await _repository.Enable(id);

            return Ok(resposta);
        }

        // Deletando Administrador
        [HttpDelete]
        [Route("deletarAdministrador/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {

            var resposta =  await _repository.Delete(id);

            return Ok(resposta);
        }


        // Update Administrador
        [HttpPut("atualizarAdministrador")]      
        public async Task<IActionResult> Update(AdministradorUpdateDTO administrador)
        {
            var resposta = await _repository.Update(administrador);

            return Ok(resposta);
        }
    }
}
