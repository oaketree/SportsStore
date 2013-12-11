using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : Abstract.IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Entities.Product> Products
        {
            get { return context.Products; }
        }
    }
}
