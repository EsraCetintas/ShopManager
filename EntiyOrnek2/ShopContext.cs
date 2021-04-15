using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiyOrnek2
{
    class ShopContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

    }
}
