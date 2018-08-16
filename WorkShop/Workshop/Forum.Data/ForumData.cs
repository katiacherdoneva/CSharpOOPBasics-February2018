using Forum.Models;
using System.Collections.Generic;

namespace Forum.Data
{
    public class ForumData
    {
        public ForumData()
        {
            this.Users = DattaMapper.LoadUsers();
            this.Categories = DattaMapper.LoadCategories();
            this.Posts = DattaMapper.LoadPosts();
            this.Replies = DattaMapper.LoadReplies();
        }

        public List<Category> Categories { get; set; }

        public List<User> Users { get; set; }

        public List<Post> Posts { get; set; }

        public List<Reply> Replies { get; set; }      

        public void SaveChanges()
        {
            DattaMapper.SaveUser(this.Users);
            DattaMapper.SaveCategories(this.Categories);
            DattaMapper.SavePost(this.Posts);
            DattaMapper.SaveReply(this.Replies);
        }
    }
}

