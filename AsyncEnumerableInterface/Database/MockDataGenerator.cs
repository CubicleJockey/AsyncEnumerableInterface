using AsyncEnumerableInterface.Database.Entities;
using Bogus;
using System;
using System.Linq;

namespace AsyncEnumerableInterface.Database
{
    public static class MockDataGenerator
    {
        private static Faker<User> userFaker = null!;
        private static Faker<Post> postFaker = null!;

        static MockDataGenerator()
        {
            InitializeUserProfile();
            InitializePostProfile();
        }

        public static IQueryable<User> GenerateUserResults(int count = 10)
        {
            return userFaker.GenerateForever()
                .Take(count)
                .AsQueryable();
        }

        public static IQueryable<Post> GeneratePostResults(int count = 10)
        {
            return postFaker.GenerateForever()
                .Take(count)
                .AsQueryable();
        }

        #region Faker Profiles

        private static void InitializeUserProfile()
        {
            userFaker = new Faker<User>()
                .StrictMode(false)
                .Rules((faker, entity) =>
                {
                    entity.Id = ++faker.IndexFaker;
                    entity.FirstName = faker.Person.FirstName;
                    entity.LastName = faker.Person.LastName;
                });
        }

        private static void InitializePostProfile()
        {
            postFaker = new Faker<Post>()
                .StrictMode(false)
                .Rules((faker, entity) =>
                {
                    entity.Id = ++faker.IndexFaker;
                    entity.Content = faker.Lorem.Paragraphs(1, 4, Environment.NewLine);
                });
        }

        #endregion Faker Profiles
    }
}
