using CadastroClientesAPI.Models.DTOs;
using System.Net.Http.Json;

namespace CadastroClientesAPI.Services
{
    public class ViaCepService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ViaCepService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ViaCep:BaseUrl"] ?? "https://viacep.com.br/ws/";
        }

        // Faz a requisição ao ViaCEP e retorna o DTO com os dados do endereço
        public async Task<EnderecoViaCepDTO?> BuscarEnderecoPorCep(string cep)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<EnderecoViaCepDTO>($"{_baseUrl}{cep}/json/");
                return response;
            }
            catch
            {
                return null; // Caso o CEP seja inválido ou a API falhe
            }
        }
    }
}
