using System.Collections.Generic;
using System.Text;

namespace AsyncEnumerableInterface.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        #region Navaigation Properities

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        #endregion Navidation Properties

        #region Overrides

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Id: [{Id}]");
            sb.AppendLine($"First Name: [{FirstName}]");
            sb.AppendLine($"Last Name: [{LastName}]");

            return sb.ToString();
        }

        #endregion Overrides
    }
}
