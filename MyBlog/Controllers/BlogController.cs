
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Services;

namespace MyBlog.Controllers 
{
    public class BlogController : Controller
    {
        private readonly IPostService _postService;
        public BlogController(IPostService postService)
        {
            _postService = postService;
        }
        public ViewResult Index()
        {
            return View("Index", _postService.GetAllPosts());
        }

    }
}
