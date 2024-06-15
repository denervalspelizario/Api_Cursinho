using Cursinho.ValidationCustom;
using System.ComponentModel.DataAnnotations;

namespace Cursinho.Dto.Administrador
{
    public class AdministradorUpdateDTO
    {
        [Required(ErrorMessage = "O ID é obrigatório.")]
        public int? id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 50 caracteres.")]
        [RegularExpression(@"^[A-Z][a-zA-Z]*(\s[A-Z][a-zA-Z]*)*$", ErrorMessage = "Cada palavra do nome deve começar com uma letra maiúscula e conter apenas letras.")]
        public string? nome { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O endereço de e-mail não é válido.")]
        public string? email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$", ErrorMessage = "A senha deve conter pelo menos uma letra e um número.")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 12 caracteres.")]
        public string? senha { get; set; }

        [Required(ErrorMessage = "O cargo é obrigatório.")]
        [ValidationCargoCustom]
        public string? cargo { get; set; }
    }
}
