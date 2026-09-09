using System;
using ConsultarApi;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var consultarApi = new ConsultaApiCep();

            Console.WriteLine("Digite seu CEP:");
            string cep = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cep))
            {
                Console.WriteLine("CEP inválido.");
                return;
            }

            consultarApi.ConsultarCep(cep.Trim());
        }
    }
}
