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
        
        public IEnumerable<product> Get()
        {
            return Repository.ProductRepository.Products();
        }

        public IEnumerable<product> Get(int page,int count)
        {
            return Repository.ProductRepository.Paginate(page, count);
        }

        // GET api/<controller>/5
       // [Authorize]
        public product Get(Guid id)
        {
            product product = Repository.ProductRepository.GetProduct(id);
            return Repository.ProductRepository.GetProduct(id);
        }

        // POST api/<controller>
        [Authorize]
        public HttpResponseMessage Post(product value)
        {
            try
            {
                Repository.ProductRepository.AddNewProduct((product)value);


            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While adding a new product"));
            }
            return null;
        }

        // PUT api/<controller>/5
        [Authorize]
        public void Put(Guid id, [FromBody]product value)
        {
            try
            {
                Repository.ProductRepository.Edit(id, value);

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
                Repository.ProductRepository.Delete(id);

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While updating a new product"));
            }
        }
    }
}