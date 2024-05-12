using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursinho.Model.Autor
{
    [Table("administradores")]
    public class Administrador
    {
        [Key]
        public int? id { get; private set; }
        public string nome { get; private set; }
        public string email { get; private set; }
        public string senha { get; private set; }
        public string cargo { get; private set; }
        public bool? status { get; private set; }
        public DateTime? data_cadastro { get; private set; }


        public Administrador(string nome, string email, string senha, string cargo, bool status, DateTime? data_cadastro)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.cargo = cargo;
            this.status = status;
            this.data_cadastro = data_cadastro;
        }

        public Administrador(string nome, string email, string cargo)
        {
            this.nome = nome;
            this.email = email;
            this.cargo = cargo;
        }

        public Administrador()
        {
        }


    }
}
