using System.ComponentModel.DataAnnotations;

namespace CorretoraDeImoveis.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "O campo Nome Completo é obrigatório.")]
        [Display(Name = "Nome Completo")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um e-mail válido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}