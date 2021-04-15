using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiyOrnek2
{
    class ProductDal
    {
        public List<Product> GetAll()
        {
            using(ShopContext context=new ShopContext())
            {
                return context.Products.ToList();

            }
        }

        public List<Product> Sorgu(String key)
        {
            using(ShopContext context=new ShopContext())
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList();
            }
        }

        public List<Product>Fiyat(decimal price)
        {
            using (ShopContext context = new ShopContext())
            {
                return context.Products.Where(p => p.UnitPrice>=price).ToList();
            }
        }
        public Product GetId(int id)
        {
            using(ShopContext context=new ShopContext())
            {
                var result = context.Products.FirstOrDefault(p => p.Id == id);
                return result;
            }
        }

        public List<Product> Aralik(decimal min,decimal max)
        {
            using(ShopContext context=new ShopContext())
            {
                return context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList();
            }
        }
        public void Add(Product product)
        {
            using(ShopContext context=new ShopContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using(ShopContext context=new ShopContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (ShopContext context = new ShopContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
