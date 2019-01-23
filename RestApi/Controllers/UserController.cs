using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RestApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        // GET api/<controller>
        [Authorize]
        public IEnumerable<user> Get()
        {
            var b = HttpContext.Current.Request;
            var a = Request;
            return Repository.UserRepository.Users();
        }

        // GET api/<controller>/5
        [Authorize]
        public user Get(Guid id)
        {
            return Repository.UserRepository.GetUser(id);
        }

        // POST api/<controller>
        
        public void Post([FromBody]user value)
        {

            
            try
            {
                Repository.UserRepository.AddNewUser(value);


            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While adding a new product"));
            }
            //return null;
        }

        // PUT api/<controller>/5
        [Authorize]
        public void Put(Guid id, [FromBody] user value)
        {
            try
            {
                Repository.UserRepository.EditUser(id, value);
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
                Repository.UserRepository.DeleteUser(id);

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error While deleting a  product"));
            }
        }

        


    }
}