using Warehouse.Models;
using System;
using System.Linq;

namespace Warehouse
{
    /// <summary>
    /// Класс заполнения базы данных (таблицы product) для тестирования.
    /// </summary>
    public class SampleDataDB
    {
        /// <summary>
        /// Метод инитиализации таблицы.
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(ProductContext context)
        {
            if (!context.products.Any())
            {
                context.products.AddRange(
                    new Product
                    {
                        Name = "iPhone X",
                        NumberProduct = 10
                    }
                );
                context.SaveChanges();
            }
        }

    }
}
