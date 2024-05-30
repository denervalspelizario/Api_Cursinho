using Cursinho.Dto.Administrador;
using Cursinho.Model.Autor;
using Cursinho.Model.Response.Administrador;
using Cursinho.ViewModel.Administrador;
using Microsoft.AspNetCore.Http.HttpResults;
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


        // UPDATE ADMINISTRADOR
        public async Task<ResponseAdministrador<AdministradorResponseViewModel>> Update(AdministradorUpdateDTO administrador)
        {
            // resposta formatada
            var resposta = new ResponseAdministrador<AdministradorResponseViewModel>();

            try
            {
                // validando se usuário passou id
                if (administrador.id == null)
                {
                    resposta.Mensagem = "Id do usuário é necessário";
                    return resposta;
                }

                // obtendo a entidade pelo id
                var adm = await _context.Administradores.FirstOrDefaultAsync(x => x.id == administrador.id);
                
                // validando se user foi encontrado
                if (adm is null)
                {
                    resposta.Mensagem = "Usuário não encontrado";
                    return resposta; 
                }

                

                // criando um objeto que irá atualizar dados da tabela 
                var admAtualizado = new Administrador(
                    adm.id,
                    administrador.nome,
                    administrador.email,
                    administrador.senha,
                    administrador.cargo,
                    adm.status,
                    adm.data_cadastro
                    );

                // alterando tabela com dados adm por dados admAtualizado
                _context.Administradores.Entry(adm).CurrentValues.SetValues(admAtualizado);


                
                // salvando os dados no banco
                _context.SaveChanges();

                // Formatando msg de resposta
                var admResponse = new AdministradorResponseViewModel(
                    admAtualizado.id,
                    admAtualizado.nome,
                    admAtualizado.email,
                    admAtualizado.cargo,
                    admAtualizado.data_cadastro
                    ); ;

                //resposta estrutura
                resposta.Dados = admResponse;
                resposta.Status = (bool)adm.status;
                resposta.Mensagem = "Dados Atualizados com Sucesso";


                // retornando resposta
                return resposta;

            }
            catch (Exception erro )
            {
                resposta.Mensagem = erro.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
