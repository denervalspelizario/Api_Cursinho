namespace Cursinho.ViewModel.Administrador
{
    public class AdministradorResponseViewModel
    {
        

        public string nome { get; set; }
        public string email { get; set; }
        public string cargo { get; set; }
        public DateTime? data_cadastro { get; set; }

        public AdministradorResponseViewModel(string nome, string email, string cargo, DateTime? data_cadastro)
        {
            this.nome = nome;
            this.email = email;
            this.cargo = cargo;
            this.data_cadastro = data_cadastro;
        }

        public AdministradorResponseViewModel()
        {
           
        }
    }
}
