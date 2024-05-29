namespace Cursinho.Model.Response.Administrador
{
    public class ResponseAdministrador<T>
    {
        public T? Dados { get; set; }
        public string? Mensagem { get; set; }
        public bool? Status { get; set; }
    }
}
