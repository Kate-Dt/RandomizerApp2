using Randomizer.DBAdapter;
using Randomizer.Models;
using Randomizer.RandomizerServiceInterface;
using System;
using System.Collections.Generic;

namespace Randomizer.RandomizerService
{
    public class RandomizerService : IQueryContract
    {
        public bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public User GetUserByGuid(Guid guid)
        {
            return EntityWrapper.GetUserByGuid(guid);
        }

        public void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        public void AddQuery(Query query)
        {
            EntityWrapper.AddQuery(query);
        }

        public List<User> GetAllUsers(Guid queryGuid)
        {
            return EntityWrapper.GetAllUsers(queryGuid);
        }

        public void DeleteQuery(Query selectedQuery)
        {
            EntityWrapper.DeleteQuery(selectedQuery);
        }

        public void SaveQuery(Query query)
        {
            EntityWrapper.SaveQuery(query);
        }        
    }
}
