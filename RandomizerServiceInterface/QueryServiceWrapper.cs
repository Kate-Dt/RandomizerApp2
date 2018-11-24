using Randomizer.Models;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Randomizer.RandomizerServiceInterface
{
    public class QueryServiceWrapper
    {
        public static bool UserExists(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IQueryContract>("Server"))
            {
                IQueryContract client = myChannelFactory.CreateChannel();
                return client.UserExists(login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IQueryContract>("Server"))
            {
                IQueryContract client = myChannelFactory.CreateChannel();
                return client.GetUserByLogin(login);
            }
        }

        public static User GetUserByGuid(Guid guid)
        {
            using (var myChannelFactory = new ChannelFactory<IQueryContract>("Server"))
            {
                IQueryContract client = myChannelFactory.CreateChannel();
                return client.GetUserByGuid(guid);
            }
        }

        public static void AddUser(User user)
        {
            using (var myChannelFactory = new ChannelFactory<IQueryContract>("Server"))
            {
                IQueryContract client = myChannelFactory.CreateChannel();
                client.AddUser(user);
            }
        }

        public static void AddQuery(Query query)
        {
            using (var myChannelFactory = new ChannelFactory<IQueryContract>("Server"))
            {
                IQueryContract client = myChannelFactory.CreateChannel();
                client.AddQuery(query);
            }
        }

        public static void SaveWallet(Query query)
        {
            using (var myChannelFactory = new ChannelFactory<IQueryContract>("Server"))
            {
                IQueryContract client = myChannelFactory.CreateChannel();
                client.SaveQuery(query);
            }
        }

        public static List<User> GetAllUsers(Guid queryGuid)
        {
            using (var myChannelFactory = new ChannelFactory<IQueryContract>("Server"))
            {
                IQueryContract client = myChannelFactory.CreateChannel();
                return client.GetAllUsers(queryGuid);
            }
        }

        public static void DeleteQuery(Query selectedQuery)
        {
            using (var myChannelFactory = new ChannelFactory<IQueryContract>("Server"))
            {
                IQueryContract client = myChannelFactory.CreateChannel();
                client.DeleteQuery(selectedQuery);
            }
        }
    }
}

