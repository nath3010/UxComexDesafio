using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UxComexDesafio.Models
{
    public class Endereco
    {
        [Key]
        public int Enderecoid { get; set; }

        [Required]
        [DisplayName("Endereço")]
        public string EnderecoNome { get; set; }
        [Required]
        public string Cep { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }

        public int Pessoaid { get; set; }
        public virtual Pessoa Pessoa { get; set; }

    }
}
