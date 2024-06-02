using Cursinho.Dto.Administrador;
using Cursinho.Model.Response.Administrador;
using Cursinho.ViewModel.Administrador;

namespace Cursinho.Model.Autor
{
    public interface IAdministradorRepository
    {
        void Add(Administrador administrador);

        Task<List<Administrador>> Get();

        Task<Administrador> GetAdministrador(int id);

        Task<Administrador> FindByName(string name);

        Task<ResponseAdministradorMessage> Disable(int id);
        Task<ResponseAdministradorMessage> Enable(int id);
        Task<ResponseAdministradorMessage> Delete(int id);

        Task<ResponseAdministrador<AdministradorResponseViewModel>> Update(AdministradorUpdateDTO administrador);
    }
}
