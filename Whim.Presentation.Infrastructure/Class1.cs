using System.Collections.Generic;
using Whim.Models;

namespace Whim.Presentation.Infrastructure
{
    public interface IDoBasicUserAdministration
    {
        void CreateUser(User user);

        IList<User> GetAllUsers();
    }
}