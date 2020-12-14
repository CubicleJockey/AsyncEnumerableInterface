using AsyncEnumerableInterface.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using AsyncEnumerableInterface.Database.Entities;

namespace AsyncEnumerableInterface.Apis
{
    /// <summary>
    /// This clearly is not a real Api but will take the place of an actual api
    /// for the purpose of demoing IAsyncEnumerable
    /// </summary>
    public class UserApi
    {
        private readonly DatabaseContext database;

        public UserApi(DatabaseContext database)
        {
            this.database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public async IAsyncEnumerable<User> GetAllUsers()
        {
            await using (database)
            {
                foreach (var user in await database.Users.ToArrayAsync())
                {
                    yield return user;
                }
            }
        }

        public async IAsyncEnumerable<Post> GetAllPosts()
        {
            await using (database)
            {
                foreach (var post in await database.Posts.ToArrayAsync())
                {
                    yield return post;
                }
            }
        }

        public async IAsyncEnumerable<Post> GetUserPost(int userId)
        {
            await using (database)
            {
                foreach(var post in database.Posts.Where(post => post.UserId == userId))
                {
                    yield return post;
                }
            }
        }
    }
}
