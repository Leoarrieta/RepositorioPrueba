using ServiciosWeb.ClienteConsole.ServiceProductoASMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServiciosWeb.ClienteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Invocar servicio ASMX
            ServicioProductoSoapClient cliente = new ServicioProductoSoapClient();
            var productos = cliente.ObtenerProductos();

            //Invocar servicio WCF
            ServiceProductoWCF.Service1Client clienteWCF = new ServiceProductoWCF.Service1Client();
            var productos2 = clienteWCF.ObtenerProductos();

            //Invocar servicio REST
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44364/");

            var request = clienteHttp.GetAsync("api/Products").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Products>>(resultString);

                foreach (var item in listado)
                {
                    Console.WriteLine(item.ProductName);
                }
                Console.ReadLine();
            }
            //clienteHttp.PostAsync();
            //clienteHttp.PutAsync();
            //clienteHttp.DeleteAsync();
        }
    }
}
