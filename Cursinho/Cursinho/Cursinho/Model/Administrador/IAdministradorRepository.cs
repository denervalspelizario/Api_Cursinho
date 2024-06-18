using Cursinho.Dto.Administrador;
using Cursinho.Model.Response.Administrador;


namespace Cursinho.Model.Autor
{
    public interface IAdministradorRepository
    {
        Task<ResponseAdministrador<AdministradorResponseDTO>> Add(AdministradorCreateDTO administrador);

        Task<ResponseAdministradorList<List<AdministradorResponseDTO>>> Get();

        Task<ResponseAdministrador<AdministradorResponseDTO>> GetAdministrador(int id);

        Task<ResponseAdministradorMessage> Disable(int id);
        Task<ResponseAdministradorMessage> Enable(int id);
        Task<ResponseAdministradorMessage> Delete(int id);

        Task<ResponseAdministrador<AdministradorResponseDTO>> Update(AdministradorUpdateDTO administrador);
    }
}
