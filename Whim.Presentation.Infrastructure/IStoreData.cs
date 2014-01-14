using System.Collections;
using System.Collections.Generic;
using Whim.Models;

namespace Whim.Presentation.Infrastructure
{
    public interface IStoreData
    {
        void CreateUser(User user);

        IList<User> SearchUsers();

        void DeleteUser(User user);
    }
}