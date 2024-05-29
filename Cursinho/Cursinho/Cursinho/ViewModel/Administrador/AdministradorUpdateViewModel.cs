namespace Cursinho.ViewModel.Administrador
{
    public class AdministradorUpdateViewModel
    {
        public int id { get; set; }
        public string? nome { get; set; }
        public string? email { get; set; }
        public string? senha { get; set; }
        public string? cargo { get; set; }
        public bool? status { get; set; }
    }
}
