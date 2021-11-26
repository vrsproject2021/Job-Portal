using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Context
{
    public class userContext : DbContext
    {
        public DbSet<users> users { get; set; }
    }
}