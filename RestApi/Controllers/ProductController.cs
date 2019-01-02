using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RestApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        // GET api/<controller>
        
        public IEnumerable<Product> Get()
        {
            return Repository.Repository.Products;
        }

        // GET api/<controller>/5
        [Authorize]
        public Product Get(Guid id)
        {
            return Repository.Repository.GetProduct(id);
        }

        // POST api/<controller>
        [Authorize]
        public HttpResponseMessage Post(Product value)
        {
            try
            {
                Repository.Repository.AddNewProduct((Product)value);


            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While adding a new product"));
            }
            return null;
        }

        // PUT api/<controller>/5
        [Authorize]
        public void Put(Guid id, [FromBody]Product value)
        {
            try
            {
                Repository.Repository.Edit(id, value);

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While updating a new product"));
            }

        }

        // DELETE api/<controller>/5
        [Authorize]
        public void Delete(Guid id)
        {

            try
            {
                Repository.Repository.Delete(id);

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While updating a new product"));
            }
        }
    }
}