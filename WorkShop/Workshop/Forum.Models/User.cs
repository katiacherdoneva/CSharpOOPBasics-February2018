using System.Collections.Generic;

namespace Forum.Models
{
    public class User
    {
        public User(string username, int id, string password, IEnumerable<int> postIds)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.PostsId = new List<int>(postIds);
        }

        public string Username { get; set; }

        public int Id { get; set; }

        public string Password { get; set; }

        public ICollection<int> PostsId { get; set; }
    }
}
