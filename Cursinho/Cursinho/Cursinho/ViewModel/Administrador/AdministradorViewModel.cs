namespace Cursinho.ViewModel.Administrador
{
    public class AdministradorViewModel
    {
        public int? id {  get; set; } 
        public string? nome { get; set; }
        public string? email { get; set; }
        public string? senha { get; set; }
        public string? cargo { get; set; }
        public bool? status { get; set; }
        public DateTime? data_cadastro { get; set; }


        public AdministradorViewModel(int? id, string? nome, string? email, string? senha, string? cargo, bool? status, DateTime? data_cadastro)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.cargo = cargo;
            this.status = status;
            this.data_cadastro = data_cadastro;
        }

        public AdministradorViewModel(int? id, string? nome, string? email, string? cargo, DateTime? data_cadastro)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.cargo = cargo;
            this.data_cadastro = data_cadastro;
        }
    }
}
