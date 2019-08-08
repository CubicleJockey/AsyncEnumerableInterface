namespace AsyncEnumerableInterface.Database.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }

        #region Navigation Properties

        public User User { get; set; }

        #endregion Navigation Properties
    }
}
