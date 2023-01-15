using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserApi.Models
{
    public class UsuarioModel
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 45, MinimumLength = 3, ErrorMessage = "Informe um nome válido.")]
        public string Name { get; set; }
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "Informe um telefone válido.")]
        public string Phone { get; set; }
        [Required, StringLength(maximumLength: 100, MinimumLength = 10, ErrorMessage = "Informe um email válido."), EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(maximumLength:20,MinimumLength = 5, ErrorMessage = "Informe uma senha válida."), PasswordPropertyText]
        public string Password { get; set; }
    }
}
