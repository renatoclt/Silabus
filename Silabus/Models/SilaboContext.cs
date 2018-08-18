using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboContext :DbContext
    {
        public SilaboContext() : base("SilaboDBContext")
        {

        }
        public DbSet<Divicion> diviciones { get; set; }
    }
}