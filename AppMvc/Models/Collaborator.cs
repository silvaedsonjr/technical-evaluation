using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppMvc.Models
{
    public class Collaborator
    {
        [Key]
        public int Id { get; set; }               

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [MaxLength(100, ErrorMessage = "No máximo 100 caracteres")]
        public string Nome { get; set; }          

        [DisplayName("Código da Unidade")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string CodigoUnidade { get; set; } 

        [DisplayName("ID da Unidade")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public int IdUnidade { get; set; }        

        public bool Ativo { get; set; }           

        public virtual List<Collaborator> Colaboradores { get; set; } = new List<Collaborator>();
    }
}