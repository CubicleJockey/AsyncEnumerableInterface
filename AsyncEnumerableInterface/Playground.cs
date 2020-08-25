using System;
using AsyncEnumerableInterface.Apis;
using AsyncEnumerableInterface.Database;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncEnumerableInterface
{
    [TestClass]
    public class Playground
    {
        private DatabaseContext database;

        public Playground()
        {
            database = new DatabaseContext(InMemoryConfiguration.Configure());
            InMemoryConfiguration.SetupData(database);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            //Setup connection per tests
            database = new DatabaseContext(InMemoryConfiguration.Configure());
        }

        [TestMethod]
        public void CheckInMemorySetup()
        {
            using (database)
            {
                database.Users.Count().Should().Be(InMemoryConfiguration.TotalUsers);
                database.Posts.Count().Should().Be(InMemoryConfiguration.TotalPosts);
            }
        }


        [TestMethod]
        public async Task GetAllUsers()
        {
            var userApi = new UserApi(database);

            await foreach (var user in userApi.GetAllUsers())
            {
                Console.WriteLine(user);
            }
        }
    }
}
