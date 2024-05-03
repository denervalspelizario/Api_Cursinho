namespace Api_Cursinho.Model
{
    public interface IAdministradoresRepository
    {
        // [3] Metodos da Tabela Administradores
        void Add(Administradores administradores); // Add Adms

        List<Administradores> GetAll(); // Listando Adms

        Administradores? Get(int id); // Listando um adm especifico
    }
}
