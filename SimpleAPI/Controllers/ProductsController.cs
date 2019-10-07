using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;

namespace SimpleAPI.Controllers
{
    //The Route we can access our API
    [Route("api/[controller]")]
    //Define this Controller as an API Controller
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Define a sample List
        List<Product> products = new List<Product>()
        {
                new Product{ProductId =1, Name="Keyboard", Category="Computer Parts", Price=10},
                new Product{ProductId =2, Name="Joystick", Category="Console Devices", Price=15.22M},
                new Product{ProductId =3, Name="Monitor", Category="Computer Parts", Price=50}
        };

        // You can Define an array List if u like and work with that
        //Product[] products = new Product[]
        //    {
        //        new Product{ProductId =1, Name="Keyboard", Category="Computer Parts", Price=10},
        //        new Product{ProductId =2, Name="Joystick", Category="Console Devices", Price=15.22M},
        //        new Product{ProductId =3, Name="Monitor", Category="Computer Parts", Price=50}
        //    };


        // GET an Enumerable List of Product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return products;
        }

        // GET a Specefic Product By Id
        [HttpGet("{id}", Name="GetProduct")]
        public ActionResult GetById(int id)
        {
            try
            {
                var product = products.Single((p) => p.ProductId == id);
                return Ok(product);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        // Add a new item to the list -> like ( api/values )
        /// <summary>
        /// It is just a sample code to show how it work which has done exactly nothing on the original list
        /// </summary>
        [HttpPost]
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        // Update an item from list -> like ( api/values/5 )
        /// <summary>
        /// It is just a sample code to show how it work which has done exactly nothing on the original list
        /// </summary>
        /// <param name="id">Product Id</param>
        [HttpPut("{id}")]
        public void UpdateProduct(int id, Product product)
        {
            var tempProduct = products.FirstOrDefault((p) => p.ProductId == id);
            //we will check if this id exist or not
            if (product != null)
            {
                tempProduct = product;
            }
        }

        // DELETE a product from List -> like (api/Products/1) 
        /// <summary>
        /// It is just a sample code to show how it work which has done exactly nothing on the original list
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>A temperory list of product which is manipulated by API</returns>
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Product>> Delete(int id)
        {
            //find the product that we want to remove from list
            var product = products.FirstOrDefault((p) => p.ProductId == id);

            //we will check if this id exist or not
            if (product!=null)
                products.Remove(product);

            return products;
        }
    }
}