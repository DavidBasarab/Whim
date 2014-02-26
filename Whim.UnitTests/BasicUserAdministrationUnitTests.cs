using System;
using Moq;
using NUnit.Framework;
using Whim.Features.Infrastructure;
using Whim.Models;
using Whim.Presentation;

namespace Whim.UnitTests
{
    [TestFixture]
    [Category("Whim.UnitTests")]
    public class BasicUserAdministrationUnitTests
    {
        private Mock<IManageUsers> manageUser;
        private User theUser;
        private BasicUserAdministration userAdministration;

        [SetUp]
        public void SetUp()
        {
            manageUser = new Mock<IManageUsers>();

            userAdministration = new BasicUserAdministration
            {
                ManageUsers = manageUser.Object
            };

            theUser = new User()
            {
                FirstName = "Patrick",
                LastName = "Stewart"
            };
        }

        [Test]
        public void CreateUserWillCallCreateUserInUserManagement()
        {
            SetCreateUser();

            userAdministration.CreateUser(theUser);

            manageUser.VerifyAll();
        }

        [Test]
        public void OnCreateUserWhenCreateUserIsCalledAnExceptionIsNotThrown()
        {
            manageUser
                    .Setup(v => v.Create(It.IsAny<User>()))
                    .Throws(new ArgumentException());

            userAdministration.CreateUser(theUser);

            manageUser.VerifyAll();
        }

        private void SetCreateUser()
        {
            manageUser.Setup(v => v.Create(theUser));
        }
    }
}