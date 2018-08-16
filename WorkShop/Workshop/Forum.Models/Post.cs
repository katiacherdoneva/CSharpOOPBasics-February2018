using System.Collections.Generic;

namespace Forum.Models
{
    public class Post
    {
        public Post(int id, string title, string content, int categotyId, int authorId, IEnumerable<int> replies)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.CategotyId = categotyId;
            this.AuthorId = authorId;
            this.Replies = new List<int>(replies);
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategotyId { get; set; }

        public int AuthorId { get; set; }

        public ICollection<int> Replies { get; set; }
    }
}
