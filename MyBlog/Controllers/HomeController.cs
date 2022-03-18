using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using System;
using System.Collections.Generic;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        List<Post> Posts;

        public HomeController()
        {
            Posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = ".NET bo'yicha maqola yozish mavsumimiz yana boshlandi  ",
                    Body = "Agar kimdir kitob yozmoqchi bo'lsa Diyorbek Mamataliyev (http://t.me/diyorbek_mamataliyev) ga murojaat qilsin.",
                    CreatedTime = DateTime.Now,
                    ImagePath = "logo.jpg"
                },
                new Post()
                {
                    Id = 2,
                    Title = ".NET bo'yicha maqola yozish mavsumimiz yana boshlandi  ",
                    Body = "Agar kimdir kitob yozmoqchi bo'lsa Diyorbek Mamataliyev (http://t.me/diyorbek_mamataliyev) ga murojaat qilsin.",
                    CreatedTime = DateTime.Now,
                    ImagePath = "photo_2021-11-27_00-43-16.jpg"
                },
                new Post()
                {
                    Id = 3,
                    Title = ".NET bo'yicha maqola yozish mavsumimiz yana boshlandi  ",
                    Body = "Agar kimdir kitob yozmoqchi bo'lsa Diyorbek Mamataliyev (http://t.me/diyorbek_mamataliyev) ga murojaat qilsin.",
                    CreatedTime = DateTime.Now,
                    ImagePath = "photo_2021-11-27_00-43-32.jpg"
                }
            };
        }

        public IActionResult Index()
        {
            return View(Posts);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
