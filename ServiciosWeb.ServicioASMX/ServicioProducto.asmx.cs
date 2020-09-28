using ServiciosWeb.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiciosWeb.ServicioASMX
{
    /// <summary>
    /// Descripción breve de ServicioProducto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioProducto : System.Web.Services.WebService
    {
        ProductoConnection BD = new ProductoConnection();
        [WebMethod]
        public List<Products> ObtenerProductos()
        {
            var listado = BD.Products.ToList();
            return listado;
        }
    }
}
