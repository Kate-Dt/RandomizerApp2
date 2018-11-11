using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Randomizer.Models
{
    [Serializable]
    public class User
    {
        #region Fields
        private Guid _guid;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _login;
        private string _password;
        private DateTime _lastLoginDate;
        private List<Query> _queries;
        #endregion 

        #region Properties
        public Guid
        Guid
        {
            get
            {
                return _guid;
            }
            private set
            {
                _guid = value;
            }
        }
        private string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        private string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        private string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }
            private set
            {
                _login = value;
            }
        }
        private string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        private DateTime LastLoginDate
        {
            get
            {
                return _lastLoginDate;
            }
            set
            {
                _lastLoginDate = value;
            }
        }

        public List<Query> Queries
        {
            get
            {
                return _queries;
            }
            private set
            {
                _queries = value;
            }
        }
        #endregion

        public User(string firstName, string lastName, string email, string login, string password) 
        {
            _guid = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _login = login;
            _lastLoginDate = DateTime.Now;
            _password = password;
        }

       private User()
      {
        _queries = new List<Query>();
      }

        private void SetPassword(string password)
        {
            _password = password;
        }

        public bool CheckPassword(string password)
        {
            try
            {
                string res2 = "password";
                return _password == res2;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CheckPassword(User userCandidate)
        {
            try
            {
                return _password == userCandidate._password;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}
