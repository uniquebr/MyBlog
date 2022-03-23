using Microsoft.AspNetCore.Http;
using MyBlog.Models;
using System.Collections.Generic;

namespace MyBlog.Services
{
    public interface IPostService
    {
        List<Post> GetAllPosts();
        Post GetById(int id);
        Post AddPost(Post newPost);
        Post UpdatePost(Post newPost);
        void DeletePost(int id);
        string SaveImage(IFormFile newFile);
    }
}
