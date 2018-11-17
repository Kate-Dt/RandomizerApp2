using Randomizer.DBAdapter;
using Randomizer.Models;
using Randomizer.Tools;
using System.Collections.Generic;

namespace Randomizer.Managers
{
    public class DBManager
    {
        private static readonly List<User> Users;

        static DBManager()
        {
            Users = SerializationManager.Deserialize<List<User>>(FileFolderHelper.StorageFilePath) ?? new List<User>();
        }

        public static bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = EntityWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }

        public static void SerializeUsers()
        {
            SerializationManager.Serialize(Users, FileFolderHelper.StorageFilePath);
        }

        public static void SerializeCurrent(User currentUser)
        {
            SerializeUsers();
        }

        public static void DeleteQuery(Query selectedQuery)
        {
            EntityWrapper.DeleteQuery(selectedQuery);
        }

        public static void AddQuery(Query query)
        {
            EntityWrapper.AddQuery(query);
        }
    }
}

