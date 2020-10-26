using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekTarifleri.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("IdentityConnection")
        {

        }

        public System.Data.Entity.DbSet<YemekTarifleri.Identity.ApplicationRole> IdentityRoles { get; set; }


        //public System.Data.Entity.DbSet<Eticaret.Identity.ApplicationUser> IdentityUsers { get; set; }
    }
}