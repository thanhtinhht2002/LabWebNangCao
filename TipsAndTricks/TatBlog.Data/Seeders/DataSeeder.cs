using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Data.Contexts;
using TatBlog.Core.Entities;

namespace TatBlog.Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly BlogDbContext _dbContext;
        public DataSeeder(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Posts.Any()) return;

            var authors = AddAuthors();
            var categories = AddCategories();
            var tags = AddTags();
            var posts = AddPosts(authors, categories, tags);
        }

        private IList<Author> AddAuthors()
        {
            var authors = new List<Author>()
            {
                new()
                {
                    FullName = "Jason Mouth",
                    UrlSlug = "jason-mouth",
                    Email ="json@gmail.com",
                    JoinedDate = new DateTime(2022,10,21)
                },
                new()
                {
                    FullName = "Jessica Wonder",
                    UrlSlug = "jessica-wonder",
                    Email ="jessica665@gmail.com",
                    JoinedDate = new DateTime(2020,4,19)
                }
            };
            _dbContext.Authors.AddRange(authors);
            _dbContext.SaveChanges();

            return authors;
        }
        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new() { Name =".Net Core", Description =".Net Core", UrlSlug = "net-core", ShowOnMenu = true,Posts = new List<Post>(){ } },
                new() { Name ="Architecture", Description ="Architecture", UrlSlug = "architecture", ShowOnMenu = true, Posts = new List<Post>(){  } },
                new() { Name ="Messaging", Description ="Messaging", UrlSlug = "messaging", ShowOnMenu = true, Posts = new List<Post>(){  } },
                new() { Name ="OOP", Description ="OOP", UrlSlug = "oop", ShowOnMenu = true, Posts = new List<Post>(){ } },
                new() { Name ="Design Patterns", Description ="Design Patterns", UrlSlug = "design-patterns", ShowOnMenu = true, Posts = new List<Post>(){ } }

            };
            _dbContext.AddRange(categories);
            _dbContext.SaveChanges();
            return categories;
        }
        private IList<Tag> AddTags()
        {
            var tags = new List<Tag>()
            {
                new() {Name = "Google", Description = "Google applications", UrlSlug="google-applications", Posts = new List<Post>(){ }},
                new() {Name = "ASP.NET MVC", Description = "Google applications", UrlSlug="google-applications", Posts = new List<Post>(){  }},
                new() {Name = "Google", Description = "Google applications", UrlSlug="google-applications", Posts = new List<Post>(){ }},
                new() {Name = "Google", Description = "Google applications", UrlSlug="google-applications", Posts = new List<Post>(){ }},
                new() {Name = "Google", Description = "Google applications", UrlSlug="google-applications", Posts = new List<Post>(){ }},
            };
            _dbContext.AddRange(tags);
            _dbContext.SaveChanges();
            return tags;
        }
        private IList<Post> AddPosts(
            IList<Author> authors,
            IList<Category> categories,
            IList<Tag> tags)
        { 
            var posts = new List<Post>();
            {
                new()
                {
                    Tile = "ASP.NET Core Diagnostic Scenarios",
                    ShortDescription = "David and friends has a great repos",
                    Description = "Here's a few great DON'T and DO examples"
                    Meta = "David and friends has a great respensitory filled
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[0],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[0]
                    }

                }
            };
            _dbContext.AddRange(posts);
            _dbContext.SaveChanges();
            return posts;
        }

    }

}
