using Randomizer.Models;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Randomizer.RandomizerServiceInterface
{
    [ServiceContract]
    public interface IQueryContract
    {
        [OperationContract]
        bool UserExists(string login);
        [OperationContract]
        User GetUserByLogin(string login);
        [OperationContract]
        User GetUserByGuid(Guid guid);
        [OperationContract]
        List<User> GetAllUsers(Guid walletGuid);
        [OperationContract]
        void AddUser(User user);
        [OperationContract]
        void AddQuery(Query query);
        [OperationContract]
        void SaveQuery(Query query);
        [OperationContract]
        void DeleteQuery(Query selectedQuery);
    }
}
