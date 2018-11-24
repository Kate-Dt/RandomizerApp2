using Randomizer.Models;
using Randomizer.RandomizerServiceInterface;

namespace Randomizer.Managers
{
    public class DBManager
    {
        public static bool UserExists(string login)
        {
            return QueryServiceWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return QueryServiceWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            QueryServiceWrapper.AddUser(user);
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = QueryServiceWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }

        public static void DeleteQuery(Query selectedQuery)
        {
            QueryServiceWrapper.DeleteQuery(selectedQuery);
        }

        public static void AddQuery(Query query)
        {
            QueryServiceWrapper.AddQuery(query);
        }
    }
}

