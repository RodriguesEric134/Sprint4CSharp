namespace CadastroClientesAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Cep { get; set; }

        public int EnderecoId { get; set; }

        // Permite null, pois será preenchido automaticamente no backend
        public Endereco? Endereco { get; set; }
    }
}
