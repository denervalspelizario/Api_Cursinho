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

        void Disable(int id);
        void Enable(int id);
        void Delete(int id);

        Task<ResponseAdministrador<AdministradorResponseViewModel>> Update(AdministradorUpdateDTO administrador);
    }
}
