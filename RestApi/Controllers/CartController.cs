using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApi.Controllers
{
    [RoutePrefix("api/Cart")]
    public class CartController : ApiController
    {

        
        [Route("DeleteProduct/{userid}/{product}")]
        //[Authorize]
        public void DeleteProduct(string userid,string product)
        {
            try
            {
               Repository.CartRepository.RemoveProduct(Guid.Parse(userid), Guid.Parse(product));
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While deleting a  product"));
            }
        }

       


        // GET api/<controller>/5
        [Authorize]
        public List<product> Get(Guid id)
        {
            List<product> products = null;
            try
            {
                products =  Repository.CartRepository.getUserProducts(id);
                return products;

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While fetching a product"));
            }
        }

        // POST api/<controller>
        //[Route("AddProduct/{id}")]
        [Authorize]
        public void AddProduct(Guid id, [FromBody] product value)
        {
            try
            {
                Repository.CartRepository.AddProduct(id, value);

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While adding a new product"));
            }
        }
        [Route("CheckOut/{userid}")]
        [Authorize]
        [HttpGet]
        public void CheckOut(Guid userid)
        {
            try
            {
                Repository.CartRepository.CheckOut(userid);

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While adding a new product"));
            }
        }
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

       // [Route("DeleteProductt/{userid}/{product}")]
       
    }
}