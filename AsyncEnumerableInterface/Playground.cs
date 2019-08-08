using System;
using System.Linq;
using AsyncEnumerableInterface.Database;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
