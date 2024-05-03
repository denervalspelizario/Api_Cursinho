using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Cursinho.Model
{
    [Table("administradores")] // linkando com tabela administradores
    public class Administradores
    {
        // Propriedades
        [Key] // indicando chave primaria
        public int id { get; private set; }
        public string nome { get; private set; }
        public string email { get; private set; }
        public string senha { get; private set; } 

        // Construtor
        public Administradores(string nome, string email, string senha)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
        }

        // Construtor
        public Administradores()
        {
        }
    }
}
