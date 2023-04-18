using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UxComexDesafio.Models
{
    public class Pessoa
    {
        [Key]
        public int Pessoaid { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        public string Telefone { get; set; }

        public List<Endereco> Endereco { get; set; }

    }
}