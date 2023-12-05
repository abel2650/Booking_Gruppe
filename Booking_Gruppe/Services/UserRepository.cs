using Booking_Gruppe.model;
using System.Collections.Generic;

namespace Booking_Gruppe.Services
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>();

        public User? UserLoggedIn { get; private set; }

        public UserRepository(bool mockData = false)
        {
            UserLoggedIn = null;

            if (mockData)
            {
                _users.Add(new User(1, "Rebin", "Ismail", true));
                _users.Add(new User(2, "Mathias", "Rebin", false));
                _users.Add(new User(3, "Marcus", "Ismail", false));
                _users.Add(new User(4, "Chris", "1234", false));
            }
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void RemoveUser(User user)
        {
            _users.Remove(user);
        }

        public bool CheckUser(string username, string password)
        {
            User? foundUser = _users.Find(u => u.Name == username && u.Pass == password);

            if (foundUser != null)
            {
                UserLoggedIn = foundUser;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LogoutUser()
        {
            UserLoggedIn = null;
        }
    }
}


