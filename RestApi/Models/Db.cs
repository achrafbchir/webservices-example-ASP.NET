using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class Db : IdentityDbContext<IdentityUser>
    {
        public Db(): base("DB", throwIfV1Schema: false)
        {

        }
        public static Db Create()
        {
            return new Db();
        }
    }
}