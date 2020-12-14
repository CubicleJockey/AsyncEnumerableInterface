using System.Text;

namespace AsyncEnumerableInterface.Database.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = null!;

        #region Navigation Properties

        public User User { get; set; } = null!;

        #endregion Navigation Properties

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"User Id: [{UserId}]");
            sb.AppendLine($"Content: [{Content}]");

            return sb.ToString();
        }
    }
}
