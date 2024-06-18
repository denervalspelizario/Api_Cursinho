using Cursinho.Dto.Administrador;
using Cursinho.Model.Autor;
using Cursinho.Model.Response.Administrador;
using Microsoft.EntityFrameworkCore;

namespace Cursinho.Infraestrutura.Autor
{
    public class AdministradorRepository : IAdministradorRepository
    {

        private readonly ConnectionContext _context = new ConnectionContext();

        // adicionando administradores
        public async Task<ResponseAdministrador<AdministradorResponseDTO>> Add(AdministradorCreateDTO administrador)
        {
            // resposta formatada
            var resposta = new ResponseAdministrador<AdministradorResponseDTO>();

            try
            {
                // todo cadastro o status se inicia com true
                var status = true; 

                // Data de Cadastro
                DateTime dataCadastro = DateTime.Today;
                DateTime dataCadastroUTC = dataCadastro.ToUniversalTime();

                // criando obj para adicionar no bd
                var admAdicionado = new Administrador(
                     administrador.nome,
                     administrador.email.ToLower(),
                     administrador.senha,
                     administrador.cargo.ToLower(),
                     status,
                     dataCadastroUTC
                     );


                _context.Administradores.Add(admAdicionado);

                _context.SaveChanges();

               // buscando user já adicionado ao bd
                var admEncontrado = await _context.Administradores.FirstOrDefaultAsync(x => x.email == admAdicionado.email);
                
                if ( admEncontrado is null ) 
                {
                    resposta.Mensagem = "Erro no sistema usuário não adicionado";
                    resposta.Status = false;
                    return resposta;
                }

                // Formatando msg de resposta
                var admResposta = new AdministradorResponseDTO(
                    admEncontrado.id, // id de user adicionado
                    admEncontrado.nome,
                    admEncontrado.email,
                    admEncontrado.cargo,
                    admEncontrado.data_cadastro
                    ); ;

                // resposta estrutura
                resposta.Dados = admResposta;
                resposta.Status = status;
                resposta.Mensagem = "Dados Adicionados com Sucesso";

                return resposta;
            }
            catch (Exception erro)
            {
                string mensagemErro = erro.Message;
                throw new Exception(mensagemErro);
            }
        }

        // listando admnistradores
        public async Task<ResponseAdministradorList<List<AdministradorResponseDTO>>> Get()
        {
            var resposta = new ResponseAdministradorList<List<AdministradorResponseDTO>>();
            try
            {
                // objeto com usuários do banco
                var listaAdmBanco = await _context.Administradores.ToListAsync();

                // objeto com Lista de objetos tipo AdministradorResponseViewModel
                var listaAdmResposta = new List<AdministradorResponseDTO>();

                // adicionando todos os adms na lista de objetos respostaFormatada
                foreach (var adm in listaAdmBanco)
                {
                    if (adm.status == true)
                    {
                        var admFormatado = new AdministradorResponseDTO
                        {
                            id = adm.id,
                            nome = adm.nome,
                            email = adm.email,
                            cargo = adm.cargo,
                            data_cadastro = adm.data_cadastro
                        };

                        listaAdmResposta.Add(admFormatado);
                    }
                }

                // resposta estrutura
                resposta.Dados = listaAdmResposta;
                resposta.Mensagem = "Requisição efetuado com sucesso";

                return resposta;
            }
            catch (Exception erro)
            {
                string mensagemErro = erro.Message;
                throw new Exception(mensagemErro);
            }
        }

        // buscando user por id
        public async Task<ResponseAdministrador<AdministradorResponseDTO>> GetAdministrador(int id)
        {
            // resposta formatada
            var resposta = new ResponseAdministrador<AdministradorResponseDTO>();
            try
            {
                var admEncontrado = await _context.Administradores.FindAsync(id);

                // validando se user foi encontrado
                if (admEncontrado is null)
                {
                    resposta.Mensagem = "Usuário não encontrado";
                    return resposta;
                }

                // Formatando msg de resposta
                var admResponse = new AdministradorResponseDTO(
                    admEncontrado.id,
                    admEncontrado.nome,
                    admEncontrado.email,
                    admEncontrado.cargo,
                    admEncontrado.data_cadastro
                    ); ;

                //resposta estrutura
                resposta.Dados = admResponse;
                resposta.Status = (bool)admEncontrado.status;
                resposta.Mensagem = "Dados de Administrador listado com Sucesso";


                // retornando resposta
                return resposta;
            }
            catch (Exception erro)
            {
                string mensagemErro = erro.Message;
                throw new Exception(mensagemErro);
            }
        }

        // Desativando status do usuário
        public async Task<ResponseAdministradorMessage> Disable(int idUsuario)
        {
            // resposta formatada
            var resposta = new ResponseAdministradorMessage();

            try
            {
                // obtendo a entidade pelo id
                var admEncontrado = await _context.Administradores.FirstOrDefaultAsync(x => x.id == idUsuario);

                // alteração do status da entidade
                admEncontrado.status = false;

                // salvando os dados
                _context.SaveChanges();

                resposta.Mensagem = "Cadastro do usuário desativado com sucesso";
                return resposta;
            }
            catch (Exception erro)
            {
                string mensagemErro = erro.Message;
                throw new Exception(mensagemErro);
            }
        }

        // Ativando status do usuário
        public async Task<ResponseAdministradorMessage> Enable(int idUsuario)
        {
            // resposta formatada
            var resposta = new ResponseAdministradorMessage();

            try
            {
                // obtendo a entidade pelo id
                var admEncontrado = await _context.Administradores.FirstOrDefaultAsync(x => x.id == idUsuario);

                // alteração do status da entidade
                admEncontrado.status = true;

                // salvando os dados
                _context.SaveChanges();

                resposta.Mensagem = "Cadastro do usuário ativo com sucesso";
                return resposta;

            }
            catch (Exception erro)
            {
                string mensagemErro = erro.Message;
                throw new Exception(mensagemErro);
            }
        }

        // Deletando dados do usuário
        public async Task<ResponseAdministradorMessage> Delete(int idUsuario)
        {
            // resposta formatada
            var resposta = new ResponseAdministradorMessage();

            try
            {

                // obtendo a entidade pelo id
                var admEncontrado = await _context.Administradores.FirstOrDefaultAsync(x => x.id == idUsuario);


                // validando se user foi encontrado
                if (admEncontrado is null)
                {
                    resposta.Mensagem = "Usuário não encontrado";
                    return resposta;
                }


                // removendo entidade do bd
                _context.Administradores.Remove(admEncontrado);

                // salvando os dados
                _context.SaveChanges();

                resposta.Mensagem = "Usuário deletado com sucesso";
                return resposta;

            }
            catch (Exception erro)
            {
                string mensagemErro = erro.Message;
                throw new Exception(mensagemErro);
            }
        }

        // UPDATE ADMINISTRADOR
        public async Task<ResponseAdministrador<AdministradorResponseDTO>> Update(AdministradorUpdateDTO administrador)
        {
            // resposta formatada
            var resposta = new ResponseAdministrador<AdministradorResponseDTO>();

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
                var admResponse = new AdministradorResponseDTO(
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
