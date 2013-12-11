using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public DbSet<Entities.Product> Products { get; set; }
    }
}
