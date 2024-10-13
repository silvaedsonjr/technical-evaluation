using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppMvc.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Login")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [MaxLength(100, ErrorMessage = "No máximo 50 caracteres")]
        public string Login { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Password { get; set; }

        public bool Ativo { get; set; }
    }
}