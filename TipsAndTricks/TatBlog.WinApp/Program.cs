using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;

var context = new BlogDbContext();

var posts = context.Posts
    .Where(p => p.Published)
    .OrderBy(p => p.Title)
    .Select(p => new
    {
        Id = p.Id,
        Title = p.Title,
        ViewCount = p.ViewCount,
        PostedDate = p.PostedDate,
        Author = p.Author.FullName,
        Category = p.Category.Name,
    }).ToList();
//Xuat ds bai viet

foreach (var post in posts)
{
    Console.WriteLine("ID       :{0}",post.Id);
    Console.WriteLine("Title    :{0}", post.Title);
    Console.WriteLine("View     :{0}", post.ViewCount);
    Console.WriteLine("Date     :{0:MM/dd/yyyy}", post.PostedDate);
    Console.WriteLine("Author   :{0}", post.Author);
    Console.WriteLine("Category :{0}", post.Category);
    Console.WriteLine("".PadRight(80,'-'));
}