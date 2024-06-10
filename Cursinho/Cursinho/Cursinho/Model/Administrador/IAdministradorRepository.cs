using Cursinho.Dto.Administrador;
using Cursinho.Model.Response.Administrador;


namespace Cursinho.Model.Autor
{
    public interface IAdministradorRepository
    {
        Task<ResponseAdministrador<AdministradorViewModel>> Add(AdministradorCreateDTO administrador);

        Task<ResponseAdministradorList<List<AdministradorViewModel>>> Get();

        Task<ResponseAdministrador<AdministradorViewModel>> GetAdministrador(int id);

        Task<ResponseAdministradorMessage> Disable(int id);
        Task<ResponseAdministradorMessage> Enable(int id);
        Task<ResponseAdministradorMessage> Delete(int id);

        Task<ResponseAdministrador<AdministradorViewModel>> Update(AdministradorUpdateDTO administrador);
    }
}
