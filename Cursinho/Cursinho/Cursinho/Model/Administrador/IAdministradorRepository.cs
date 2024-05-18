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

        void Delete(int id);
    }
}
