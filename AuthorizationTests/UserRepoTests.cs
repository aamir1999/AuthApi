using AuthorizationAPI.DBLayer;
using AuthorizationAPI.Models;
using AuthorizationAPI.Provider;
using AuthorizationAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace AuthorizationTests
{
    public class UserRepoTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetUserCred_Test()
        {
            User u = new User();
            DbContextOptions<UserContext> Options = new DbContextOptions<UserContext>();
            UserContext cc = new UserContext(Options);
            Mock<IUserProvider> mockDataLayer = new Mock<IUserProvider>();
            mockDataLayer.Setup(x => x.UserPassExists(u, cc)).Returns(true);
            UserRepo userobj = new UserRepo(mockDataLayer.Object);
            bool ans = userobj.GetUserCred(u, cc);
            Assert.IsTrue(ans);

        }
    }
}