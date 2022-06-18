using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Warehouse.Models
{
    public class ProductRepository
    {

        /// <summary>
        /// Получение полного списка товаров. 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Product> GetProduct(ProductContext context)
        {
            return context.products.OrderBy(x=>x.Id);
        }

        /// <summary>
        /// Получение товара по ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(ProductContext context,int id)
        {
            return context.products.Single(x => x.Id == id);
        }

        /// <summary>
        /// Сохранение в таблице с товарами.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public int SaveProduct(ProductContext context,Product product)
        {
            if(product.Id == default)
            {
                context.Entry(product).State = EntityState.Added;
            }
            else
            {
                context.Entry(product).State = EntityState.Modified;
            }
            context.SaveChanges();
            return product.Id;
        }

        /// <summary>
        /// Удаление товара из таблицы товаров.
        /// </summary>
        /// <param name="product"></param>
        public void DeliteProduct(ProductContext context, Product product)
        {
            context.products.Remove(product);
            context.SaveChanges();
        }
    }
}
