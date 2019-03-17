using Microsoft.EntityFrameworkCore;
using ORMApp.Data;
using ORMApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORMApp.Business
{
    public class ProductController
    {
        private ShopContext context;

        public ProductController()
        {
            this.context = new ShopContext();
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product Get(int Id)
        {
            var product = this.context.Products.FirstOrDefault(x => x.Id == Id);
            return product;
        }

        public void Add(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        public void Update(Product product)
        {
            var productItem = this.Get(product.Id);
            if (productItem != null)
            {
                this.context.Entry(productItem).CurrentValues.SetValues(product);
                this.context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var productItem = this.Get(id);
            this.context.Products.Remove(productItem);
            this.context.SaveChanges();
        }
    }
}
