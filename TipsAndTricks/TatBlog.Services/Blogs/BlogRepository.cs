using System;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Data.Contexts;
using TatBlog.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace TatBlog.Services.Blogs;

public class BlogRepository : IBlogRepository
{
    private readonly IBlogRepository _context;
    public BlogRepository(BlogRepository context)
    {
        _context = context;
    }
    //Tìm bài viết có tên định dạng 'Slug'
    // và đc đăng vào tháng/ năm
    public async Task<Post> GetPostAsync(
        int year,
        int month,
        string slug,
        CancellationToken cancellationToken=default)
    {
        IQueryable<Post> postsQuery = _context.Set<Post>()
            .Include(x => x.Category)
            .Include(x => x.Author);

        if (year>0)
        {
            postsQuery = postsQuery.Where(x => x.PostedDate.Year == year);
        }
        if (month > 0)
        {
            postsQuery = postsQuery.Where(x => x.PostedDate.Month == month);
        }
        if (!string.IsNullOrWhiteSpace(slug))
        {
            postsQuery = postsQuery.Where(x=>x.UrlSlug==slug);
        }
        return await postsQuery.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IList<Post>> GetPopularArticlesAsync(
        int numPosts, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Post>()  
            .Include(x => x.Author)
            .Include(x => x.Category)
            .OrderbyDescanding(p=>p.ViewCount)
            .Take(numPosts)
            .ToListAsync(cancellationToken);
    }

    public Task<bool> IsPostSlugExisteedAsync(
        int postId,
        string slug,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task IncreaseViewCountAsync(
        int postId,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

   
}
