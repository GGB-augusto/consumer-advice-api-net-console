using System;
using System.Net.Http;
using System.Text.Json;

Console.OutputEncoding = System.Text.Encoding.UTF8;

HttpClient cliente = new HttpClient();
string url = "https://api.adviceslip.com/advice";

Console.WriteLine("Iniciando requisição para obter dados de um conselho:");
Console.WriteLine();
Console.WriteLine(" " + url);
Console.WriteLine();

// pega o texto que a api devolve
string resposta = await cliente.GetStringAsync(url);

// transforma o texto em json e pega o conselho
JsonDocument json = JsonDocument.Parse(resposta);
string? conselho = json.RootElement.GetProperty("slip").GetProperty("advice").GetString();

Console.WriteLine("Conselho de Hoje:");
Console.WriteLine(conselho);