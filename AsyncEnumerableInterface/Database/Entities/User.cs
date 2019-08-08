using System.Collections.Generic;

namespace AsyncEnumerableInterface.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #region Navaigation Properities

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        #endregion Navidation Properties
    }
}
