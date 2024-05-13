using Cursinho.Model.Autor;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace Cursinho.Infraestrutura.Autor
{
    public class AdministradorRepository : IAdministradorRepository
    {

        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Administrador administrador)
        {
            try
            {
                _context.Administradores.Add(administrador);

                _context.SaveChanges();

            }
            catch (Exception erro)
            {
                string mensagemErro = erro.Message;
                throw new Exception(mensagemErro);
            }
            
        }

        public async Task<List<Administrador>> Get()
        {
            try
            {
                var adms = await _context.Administradores.ToListAsync();

                return adms;
            }
            catch (Exception erro)
            {
                string mensagemErro = erro.Message;
                throw new Exception(mensagemErro);
            }

            
        }

        public async Task<Administrador> GetAdministrador(int id)
        {
            return await _context.Administradores.FindAsync(id);
        }


        public async Task<Administrador> FindByName(string name)
        {
            try
            {
                return _context.Administradores.FirstOrDefault(x => x.nome == name);
            }
            catch (Exception erro)
            {
                string mensagemErro = erro.Message;
                throw new Exception(mensagemErro);
            }
        }
    }
}
