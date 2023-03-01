using TatBlog.Core.Entities;
namespace TatBlog.Services.Blogs;

public interface IBlogRepository
{
    //Tìm bài viết có tên định dạng 'Slug'
    // và đc đăng vào tháng/ năm
    Task<Post> GetPostAsync(
        int year,
        int month,
        string slug,
        CancellationToken cancellationToken = default);

    // Tim top N bai viet pho bien dc nhieu ng` xem
    Task<IList<Post>> GetPopularArticlesAsync(
        int numPosts,
        CancellationToken cancellationToken = default);

    // kiem tra xem ten dinh danh bai viet da co hay chua
    Task<bool> IsPostSlugExisteedAsync(
        int postId, string slug,
        CancellationToken cancellationToken = default);
  

    //tang so luot xem
    Task IncreaseViewCountAsync(
        int postId,
        CancellationToken cancellationToken = default);
    object Set<T>();
}
