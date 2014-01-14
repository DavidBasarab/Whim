using System;
using System.Collections.Generic;
using Whim.Models;

namespace Whim.Presentation
{
    public class BasicUserAdministration
    {
        private static readonly Lazy<BasicUserAdministration> instance = new Lazy<BasicUserAdministration>(() => new BasicUserAdministration());

        public static BasicUserAdministration Instance
        {
            get { return instance.Value; }
        }

        private BasicUserAdministration() {}

        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}