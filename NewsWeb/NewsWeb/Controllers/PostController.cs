using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewsWeb.Models;
using NewsWeb.Views.ViewModels;

namespace NewsWeb.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var posts = _appDbContext.Posts.Include(p => p.Category).ToList();

            return View(posts);
        }
        public IActionResult Create()
        {
            PostCreateVM postVM = new PostCreateVM()
            {
                Post = new Post(),
                CategorySelectList = _appDbContext.Categories.Select(item => new SelectListItem
                {
                    Text = item.Title,
                    Value = item.Id.ToString()
                }),
                TagSelectList = _appDbContext.Tags.Select(item => new SelectListItem
                {
                    Text = item.Title,
                    Value = item.Id.ToString()
                })
            };
            return View(postVM);
        }
        [HttpPost]
        public IActionResult Create(PostCreateVM postCreateVM)
        {
            foreach (var item in postCreateVM.SelectListTagIds)
            {
                postCreateVM.Post.PostTags.Add(new PostTag()
                {
                    TagId = item
                });
            }

            _appDbContext.Posts.Add(postCreateVM.Post);

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

