using System;
using AsyncEnumerableInterface.Apis;
using AsyncEnumerableInterface.Database;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

using static System.Console;

namespace AsyncEnumerableInterface
{
    [TestClass]
    public class Playground
    {
        private DatabaseContext database;
        private UserApi users;

        public Playground()
        {
            database = new DatabaseContext(InMemoryConfiguration.Configure());
            InMemoryConfiguration.SetupData(database);

            users = new UserApi(database);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            //Setup connection per tests
            database = new DatabaseContext(InMemoryConfiguration.Configure());
            users = new UserApi(database);
        }

        [TestMethod]
        public void CheckInMemorySetup()
        {
            //Assume defaults used here.
            using (database)
            {
                database.Users.Count().Should().Be(InMemoryConfiguration.TotalUsers);
                database.Posts.Count().Should().Be(InMemoryConfiguration.TotalPosts);
            }
        }


        [TestMethod]
        public async Task GetAllUsers()
        {
            await foreach (var user in users.GetAllUsers())
            {
                WriteLine(user);
            }
        }

        [TestMethod]
        public async Task GetAllPosts()
        {
            await foreach (var post in users.GetAllPosts())
            {
                WriteLine(post);
            }
        }

        [DataRow(1)]
        [DataRow(5)]
        [DataTestMethod]
        public async Task GetPostForUser(int userId)
        {
            WriteLine($"Getting posts for User Id: [{userId}]");

            await foreach (var post in users.GetUserPost(userId))
            {
                WriteLine(post);
            }

            WriteLine("-------------------------");
        }
    }
}
