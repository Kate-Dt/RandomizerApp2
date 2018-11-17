using Randomizer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Randomizer.DBAdapter
{
    public static class EntityWrapper
    {
        public static bool UserExists(string login)
        {
            using (var context = new RandomizerDBContext())
            {
                return context.Users.Any(u => u.Login == login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var context = new RandomizerDBContext())
            {
                return context.Users.Include(u => u.Queries).FirstOrDefault(u => u.Login == login);
            }
        }

        public static User GetUserByGuid(Guid guid)
        {
            using (var context = new RandomizerDBContext())
            {
                return context.Users.Include(u => u.Queries).FirstOrDefault(u => u.Guid == guid);
            }
        }

        public static List<User> GetAllUsers(Guid queryGuid)
        {
            using (var context = new RandomizerDBContext())
            {
                return context.Users.Where(u => u.Queries.All(r => r.Guid != queryGuid)).ToList();
            }
        }

        public static void AddUser(User user)
        {
            using (var context = new RandomizerDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void AddQuery(Query query)
        {
            using (var context = new RandomizerDBContext())
            {
                query.DeleteDatabaseValues();
                context.Queries.Add(query);
                context.SaveChanges();
            }
        }

        public static void SaveQuery(Query query)
        {
            using (var context = new RandomizerDBContext())
            {
                context.Entry(query).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void DeleteQuery(Query selectedQuery)
        {
            using (var context = new RandomizerDBContext())
            {
                selectedQuery.DeleteDatabaseValues();
                context.Queries.Attach(selectedQuery);
                context.Queries.Remove(selectedQuery);
                context.SaveChanges();
            }
        }
    }
}