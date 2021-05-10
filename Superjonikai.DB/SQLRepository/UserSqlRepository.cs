using System;
using System.Collections.Generic;
using System.Text;
using Superjonikai.Model.Repository;
using Superjonikai.Model;
using System.Linq;
using Superjonikai.Model.Entities;


namespace Superjonikai.DB.SQLRepository
{
    public class UserSqlRepository: IUserRepository
    {
        private readonly DBContext context;

        public UserSqlRepository(DBContext context)
        {
            this.context = context;
        }
        public User Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            User user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }

        public User Get(int id)
        {
            return context.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User Update(User updatedUser)
        {
            var day = context.Users.Attach(updatedUser);
            day.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedUser;
        }
    }
}
