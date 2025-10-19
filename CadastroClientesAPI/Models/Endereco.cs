using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CadastroClientesAPI.Models
{
    [Table("ENDERECO")]
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(9)] public string Cep { get; set; }
        [MaxLength(100)] public string Logradouro { get; set; }
        [MaxLength(100)] public string Bairro { get; set; }
        [MaxLength(100)] public string Localidade { get; set; }
        [MaxLength(2)] public string Uf { get; set; }

        // <-- Quebra o ciclo aqui
        [JsonIgnore]
        public ICollection<Cliente>? Clientes { get; set; }
    }
}
