using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;

namespace RestApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        // GET api/<controller>
        [Authorize]
        public IEnumerable<User> Get()
        {
            var b = HttpContext.Current.Request;
            var a = Request;
            return Repository.Repository.Users;
        }

        // GET api/<controller>/5
        [Authorize]
        public User Get(Guid id)
        {
            return Repository.Repository.GetUser(id);
        }

        // POST api/<controller>
        
        public void Post([FromBody]User value)
        {
            var b = HttpContext.Current.Request;
            var a = Request;
            
            try
            {
                Repository.Repository.AddNewUser(value);


            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While adding a new product"));
            }
            //return null;
        }

        // PUT api/<controller>/5
        [Authorize]
        public void Put(Guid id, [FromBody] User value)
        {
            try
            {
                Repository.Repository.EditUser(id, value);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While updating a  product"));
            }
            //return null;
        }

        // DELETE api/<controller>/5
        [Authorize]
        public void Delete(Guid id)
        {
            try
            {
                Repository.Repository.DeleteUser(id);

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While deleting a  product"));
            }
        }

        [Authorize]
        public void AddProduct(Guid id, [FromBody] Product value)
        {
            try
            {
                Repository.Repository.AddProduct(id, value);

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While adding a new product"));
            }
        }
        [Route("DeleteProduct/{userid}/{product}")]
        [Authorize]
        public void DeleteProduct(Guid userid, Guid product)
        {
            try
            {
                Repository.Repository.RemoveProduct(userid, product);

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While deleting a  product"));
            }
        }

        public List<Product> getUserProducts(Guid id)
        {
            try
            {
                return Repository.Repository.getUserProducts(id);

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While fetching a product"));
            }
        }


    }
}