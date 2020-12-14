using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AsyncEnumerableInterface.Database
{
    public static class InMemoryConfiguration
    {
        private static readonly Random random;


        public static int TotalUsers => 20;
        public static int TotalPosts => 400;

        static InMemoryConfiguration()
        {
            random = new Random();
        }


        public static DbContextOptions Configure() => new DbContextOptionsBuilder().UseInMemoryDatabase("PostDb").Options;


        public static void SetupData(DatabaseContext database, int? totalUsers = null, int? totalPosts = null)
        {
            totalUsers ??= TotalUsers;
            totalPosts ??= TotalPosts;

            //Create users and gather all their Ids
            var users = MockDataGenerator.GenerateUserResults(totalUsers.Value).ToArray();
            var allUserIds = users.Select(user => user.Id);

            //Generate posts and then assign users to those posts
            var posts = MockDataGenerator.GeneratePostResults(totalPosts.Value).ToList();
            posts.ForEach(post => post.UserId = random.Next(1, allUserIds.Max()));
            
            using (database)
            {
                database.Users.AddRange(users);
                database.Posts.AddRange(posts);

                database.SaveChanges();
            }
        }
    }
}
