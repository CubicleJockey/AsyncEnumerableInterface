using AsyncEnumerableInterface.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
