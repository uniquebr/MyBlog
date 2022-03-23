using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyBlog.Services
{


    public class PostService : IPostService
    {

        List<Post> allPosts;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PostService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
           
            allPosts = new List<Post>()
            {
                new Post
                {
                    Id = Guid.Parse("57b0c8cd-80d7-4dd7-b1e4-1bd5583503c9"),
                    Title = "My First Post",
                    Body ="Some Words",
                    CreatedTime = DateTime.Now,
                    ImagePath="photo_2021-11-27_00-43-16.jpg"

                },

                new Post
              {
                 Id = Guid.Parse("a37c2086-87d6-459e-b25c-1de7850ec1f8"),
                 Title = "My secon Post",
                 Body = "Some Whttps://www.youtube.com/watch?v=kpBYtFwjyQs&list=PLAXSS6gGBPcXVCWyt9G2qvfBnxskXHHQs&index=1ords",
                 CreatedTime = DateTime.Now,
                 ImagePath = "photo_2021-11-27_00-43-32.jpg"

              }
            };
        }

        public Post AddPost(Post newPost)
        {
            newPost.Id = Guid.NewGuid();
            newPost.CreatedTime = DateTime.Now;
            allPosts.Add(newPost);
            return newPost;
        }


        public void DeletePost(Guid id)
        {
            Post post = allPosts.FirstOrDefault(p => p.Id == id);
            if (post.ImagePath != null)
            {
                string uplodFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                string filePath = Path.Combine(uplodFolder, post.ImagePath);
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }    
            allPosts.Remove(post);
        }

        public List<Post> GetAllPosts()
        {
            return allPosts;
        }


        public Post GetById(Guid id)
        {
            return allPosts.FirstOrDefault(post => post.Id == id);
        }

     
        public string SaveImage(IFormFile newFile)
        {
            string uniqueName = string.Empty;
            if (newFile.FileName is not null)
            {
                string uplodFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueName = Guid.NewGuid().ToString() + "_" + newFile.FileName;
                string filepath = Path.Combine(uplodFolder, uniqueName);
                FileStream fileStream =new FileStream(filepath, FileMode.Create);
                newFile.CopyTo(fileStream);
                fileStream.Close();
            }
            return uniqueName;
        }

        public Post UpdatePost(Post post)
        {
            foreach (var p in allPosts)
            {
                if (p.Id == post.Id)
                {
                    p.Title = post.Title;
                    p.Body = post.Body;
                    p.ImagePath = post.ImagePath;
                }
                   
            }
            return post;
        }

       
        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int id)
        {
            throw new NotImplementedException();
        }
    }
}
