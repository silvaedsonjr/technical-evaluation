using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AppMvc.Models
{
    public class Collaborator
    {
        [Key]
        public int Id { get; set; }               // ID único do colaborador

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [MaxLength(100, ErrorMessage = "No máximo 100 caracteres")]
        public string Nome { get; set; }          // Nome do colaborador

        [DisplayName("Código da Unidade")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string CodigoUnidade { get; set; } // Código único da unidade

        [DisplayName("ID da Unidade")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public int IdUnidade { get; set; }        // ID único da unidade

        public bool Ativo { get; set; }           // Status do colaborador (ativo ou inativo)

        public virtual List<Collaborator> Colaboradores { get; set; } = new List<Collaborator>(); // Lista de colaboradores
    }
}