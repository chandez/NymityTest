using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nymity.Core.Entities;
using Nymity.Core.Repositories;

namespace Nymity.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _productRepository.Get();
            return products;
        }

        // GET: api/Products/5
        //[HttpGet("{id}", Name = "Get")]
        //public Product Get(int id)
        //{
        //    var product = _productRepository.Get(id);
        //    return product;
        //}

        //// POST: api/Products
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Products/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
