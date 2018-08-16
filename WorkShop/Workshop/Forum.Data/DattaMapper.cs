using Forum.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Forum.Data
{
    public class DattaMapper
    {
        private const string DATA_PATH = "../data/";

        private const string CONFIG_PATH = "config.ini";

        private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

        private static readonly Dictionary<string, string> config;

        static DattaMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);

        }

        private static void EnsureConfigFile(string configPath)
        {
            if(!File.Exists(configPath))
            {
                File.WriteAllText(configPath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
        {
            if(!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);

            var contents = ReadLines(configPath);

            var config = contents
                .Select(l => l.Split('='))
                .ToDictionary(t => t[0], t => DATA_PATH + t[1]);

            return config;
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);
            var lines = File.ReadAllLines(path);
            return lines;
        }

        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        public static List<Category> LoadCategories()
        {
            List<Category> categories = new List<Category>();
            var dataLines = ReadLines(config["categories"]);


            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var name = args[1];
                var postIdds = args[2]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();


                Category category = new Category(name, id, postIdds);
                categories.Add(category);
            }
            return categories;
        }

        public static void SaveCategories(List<Category> categories)
        {
            List<string> lines = new List<string>();

            foreach (var category in categories)
            {
                const string categoryFormat = "{0};{1};{2}";
                string line = string.Format(categoryFormat,
                    category.Id,
                    category.Name,
                    string.Join(",", category.Posts)
                    );

                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());                      
        }

        public static List<User> LoadUsers()
        {
            List<User> users = new List<User>();
            var dataLines = ReadLines(config["users"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var username = args[1];
                var password = args[2];
                List<int> postIdds = args[3]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();


                User user = new User(username, id, password, postIdds);
                users.Add(user);
            }
            return users;
        }

        public static void SaveUser(List<User> users)
        {
            List<string> lines = new List<string>();

            foreach (var user in users)
            {
                const string userFormat = "{0};{1};{2};{3}";
                string line = string.Format(userFormat, user.Id, user.Username, user.Password, string.Join(",", user.PostsId));

                lines.Add(line);

            }
            WriteLines(config["users"], lines.ToArray());
        }

        public static List<Post> LoadPosts()
        {
            List<Post> posts = new List<Post>();
            var dataLines = ReadLines(config["posts"]);


            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var title = args[1];
                var content = args[2];
                var categoryId = args[3];
                var authorId = args[4];

                var replies = args[5]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();


                Post post = new Post(id, title, content, int.Parse(categoryId), int.Parse(authorId), replies);
                posts.Add(post);
            }
            return posts;
        }

        public static void SavePost(List<Post> posts)
        {
            List<string> lines = new List<string>();

            foreach (var post in posts)
            {
                const string userFormat = "{0};{1};{2};{3};{4};{5}";
                string line = string.Format(userFormat, post.Id, post.Title, post.Content, post.Id, post.AuthorId, string.Join(",", post.Replies));

                lines.Add(line);

            }
            WriteLines(config["posts"], lines.ToArray());
        }

        public static List<Reply> LoadReplies()
        {
            List<Reply> replies = new List<Reply>();
            var dataLines = ReadLines(config["replies"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var content = args[1];
                var authorId = args[2];
                var postIdds = args[3];


                Reply reply = new Reply(id, content, int.Parse(authorId), int.Parse(postIdds));
                replies.Add(reply);
            }
            return replies;
        }

        public static void SaveReply(List<Reply> replies)
        {
            List<string> lines = new List<string>();

            foreach (var reply in replies)
            {
                const string cateforyFormat = "{0};{1};{2};{3}";

                string line = string.Format(cateforyFormat, reply.Id, reply.Content, reply.AuthorId, reply.Id);

                lines.Add(line);

            }
            WriteLines(config["replies"], lines.ToArray());
        }
    }  
}
