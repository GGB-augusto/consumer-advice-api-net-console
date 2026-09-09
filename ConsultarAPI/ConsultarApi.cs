using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace ConsultarApi
{
    public class ConsultaApiCep
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public void ConsultarCep(string cep)
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                var response = _httpClient.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var endereco = JsonConvert.DeserializeObject<Endereco>(jsonResponse);

                if (endereco != null && !string.IsNullOrEmpty(endereco.Cep))
                {
                    Console.WriteLine($"CEP: {endereco.Cep}");
                    Console.WriteLine($"Logradouro: {endereco.Logradouro}");
                    Console.WriteLine($"Bairro: {endereco.Bairro}");
                    Console.WriteLine($"Cidade: {endereco.Localidade}");
                    Console.WriteLine($"Estado: {endereco.Uf}");
                }
                else
                {
                    Console.WriteLine("CEP não encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar o CEP: {ex.Message}");
            }
        }
    }

    public class Endereco
    {
        [JsonProperty("cep")] public string Cep { get; set; }
        [JsonProperty("logradouro")] public string Logradouro { get; set; }
        [JsonProperty("bairro")] public string Bairro { get; set; }
        [JsonProperty("localidade")] public string Localidade { get; set; }
        [JsonProperty("uf")] public string Uf { get; set; }
    }
}
