using System;
using System.Collections.Generic;
using System.IO;
using Whim.Features.Infrastructure;
using Whim.Models;
using Whim.Presentation.Infrastructure;

namespace Whim.Presentation
{
    public class BasicUserAdministration : IDoBasicUserAdministration
    {
        private static readonly Lazy<BasicUserAdministration> instance = new Lazy<BasicUserAdministration>(() => new BasicUserAdministration());

        public static BasicUserAdministration Instance
        {
            get { return instance.Value; }
        }

        public IManageUsers ManageUsers { get; set; }

        public BasicUserAdministration() {}

        public void CreateUser(User user)
        {
            try
            {
                ProcessCreateUser(user);
            }
            catch (Exception ex)
            {
                HandelException(ex);
            }
        }

        private void HandelException(Exception exception)
        {
        }

        private void ProcessCreateUser(User user)
        {
            ManageUsers.Create(user);
        }

        public IList<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}