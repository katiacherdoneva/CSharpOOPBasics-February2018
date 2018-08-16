using System.Collections.Generic;

namespace Forum.Models
{
    public class Category
    {
        public Category(string name, int id, IEnumerable<int> posts)
        {
            this.Name = name;
            this.Id = id;
            this.Posts = new List<int>(posts);
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public ICollection<int> Posts { get; set; }
    }
}
