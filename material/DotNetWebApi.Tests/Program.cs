using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace DotNetWebApi.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5000");
            var response = Client.GetAsync("(api/v1/todos").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Conexion exitosa");
                string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Console.WriteLine($"Contend {content}");
                var json = JsonConvert.DeserializeObject<JArray>(content);
                Console.WriteLine($"Array {json}");
                Console.WriteLine($"Elemento 0 {json[0]}");

                Console.WriteLine($"Tittle 0 {json[0]["tittle"]}");
            }
            else
            {
                Console.WriteLine("Error en la respuesta");
            }
            Console.WriteLine(response);

            Console.WriteLine("Hello World!");
        }
    }
}
