using ServiciosWeb.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosWeb.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        #region
        ProductoConnection bd = new ProductoConnection();
        #endregion
        //Permite consultar la informacion de todos los productos
        [HttpGet]
        public IEnumerable<Products> Get()
        {
            var listado = bd.Products.ToList();
            return listado;
        }
        [HttpGet]
        public Products Get(int id)
        {
            var producto = bd.Products.FirstOrDefault(x => x.ProductID == id);
            return producto;
        }

        [HttpPost]
        public bool InsertProduct(Products productItem)
        {
            bool status;
            try
            {
                bd.Products.Add(productItem);
                bd.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        [HttpPut]
        public bool UpdateProduct(Products productItem)
        {
            bool status;
            try
            {
                Products prodItem = bd.Products.Where(p => p.ProductID == productItem.ProductID).FirstOrDefault();
                if (prodItem != null)
                {
                    prodItem.ProductName = productItem.ProductName;
                    prodItem.QuantityPerUnit = productItem.QuantityPerUnit;
                    prodItem.UnitPrice = productItem.UnitPrice;
                    prodItem.UnitsInStock = productItem.UnitsInStock;
                    prodItem.UnitsOnOrder = productItem.UnitsOnOrder;
                    prodItem.ReorderLevel = productItem.ReorderLevel;
                    prodItem.Discontinued = productItem.Discontinued;


                    bd.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        [HttpDelete]
        public bool DeleteProduct(int id)
        {
            bool status;
            try
            {
                Products prodItem = bd.Products.Where(p => p.ProductID == id).FirstOrDefault();
                if (prodItem != null)
                {
                    bd.Products.Remove(prodItem);
                    bd.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
