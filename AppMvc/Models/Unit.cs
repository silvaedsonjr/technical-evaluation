using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AppMvc.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Código de Unidade Único")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [MaxLength(50, ErrorMessage = "No máximo 50 caracteres")]
        public string UniqueCode { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [MaxLength(100, ErrorMessage = "No máximo 100 caracteres")]
        public string Name { get; set; }

        [DisplayName("Status")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public bool IsActive { get; set; } // Propriedade de status

        // Lista de colaboradores associados a esta unidade
        //public ICollection<Collaborator> Collaborators { get; set; }
    }
}