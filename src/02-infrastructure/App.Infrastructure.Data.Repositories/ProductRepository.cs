using App.Domain.Core.Entities;
using App.Infrastructure.DB.SqlServer.EF.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
