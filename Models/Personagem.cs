using System.ComponentModel.DataAnnotations;

namespace ProjetoUm.Models
{
    public class Personagem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Nome precisa ter no máximo 50 caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Nome precisa ter no máximo 50 caracteres")]
        public String Tipo { get; set; }

    }
    
}