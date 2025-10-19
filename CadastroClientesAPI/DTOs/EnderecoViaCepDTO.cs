namespace CadastroClientesAPI.Models.DTOs
{
    // Objeto usado para mapear o retorno da API ViaCEP
    public class EnderecoViaCepDTO
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
    }
}
