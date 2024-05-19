using Cursinho.Model.Autor;
using Cursinho.ViewModel.Administrador;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

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
            
            try
            {
                return await _context.Administradores.FindAsync(id);
            }
            catch (Exception erro)
            {
                string mensagemErro = erro.Message;
                throw new Exception(mensagemErro);
            }
        }


        public async Task<Administrador> FindByName(string name)
        {
            try
            {
                return await _context.Administradores.FirstOrDefaultAsync(x => x.nome == name);
            }
            catch (Exception erro)
            {
                string mensagemErro = erro.Message;
                throw new Exception(mensagemErro);
            }
        }

        public async void Disable(int id)
        {
            try
            {
                // obtendo a entidade pelo id
                var adm = await _context.Administradores.FirstOrDefaultAsync(x => x.id == id);

                // alteração do status da entidade
                adm.status = false;

                // salvando os dados
                _context.SaveChanges();
            }
            catch (Exception erro)
            {
                string mensagemErro = erro.Message;
                throw new Exception(mensagemErro);
            }
        }


        public async void Enable(int id)
        {
            try
            {
                // obtendo a entidade pelo id
                var adm = await _context.Administradores.FirstOrDefaultAsync(x => x.id == id);

                // alteração do status da entidade
                adm.status = true;

                // salvando os dados
                _context.SaveChanges();
            }
            catch (Exception erro)
            {
                string mensagemErro = erro.Message;
                throw new Exception(mensagemErro);
            }
        }


        public async void Delete(int id)
        {
            try
            {
                // obtendo a entidade pelo id
                var adm = await _context.Administradores.FirstOrDefaultAsync(x => x.id == id);

                // removendo entidade do bd
                _context.Administradores.Remove(adm);

                // salvando os dados
                _context.SaveChanges();
            }
            catch (Exception erro)
            {
                string mensagemErro = erro.Message;
                throw new Exception(mensagemErro);
            }
        }
    }
}
