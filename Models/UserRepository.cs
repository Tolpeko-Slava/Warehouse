using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Warehouse.Models
{
    public class UserRepository
    {
        public IQueryable<UserClass> GetUsers(ProductContext context)
        {
            return context.UserWarehouse.OrderBy(x => x.Login);
        }

        /// <summary>
        /// Проверка на существование данного Login в базе данных.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public bool FindUserLogin(ProductContext context, UserClass user)
        {
            IQueryable<UserClass> result = context.UserWarehouse.Where(x => x.Login == user.Login);
            return result.Any();
        }

        public bool SaveUser(ProductContext context, UserClass user)
        {
            if (user.Login == default)
            {
                context.Entry(user).State = EntityState.Added;
                context.SaveChanges();
                return true;
            }
            else
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return false;
            }

        }

        public void DeleteUser(ProductContext context, UserClass user)
        {
            context.UserWarehouse.Remove(user);
            context.SaveChanges();
        }
        
    }
}
