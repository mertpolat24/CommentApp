using CommentApp_Cores.Enums;
using CommentApp_Cores.Models;
using CommentApp_Services.Contracts;
using CommentApp_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CommentApp_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICommentService _commentService;
        private readonly ICategoryService _categoryService;

        public HomeController(
            ILogger<HomeController> logger,
            ICommentService commentService,
            ICategoryService categoryService)
        {
            _logger = logger;
            _commentService = commentService;
            _categoryService = categoryService;
        }

        public IActionResult Index(string sortType = "newest", int? categoryId = null)
        {
            var comments = _commentService.GetAllComments().Where(c => c.Status == Status.Active)
                .Include(c => c.Category)
                .AsQueryable();


            if (categoryId.HasValue)
                comments = comments.Where(c => c.Category.Id == categoryId);

            comments = sortType switch
            {
                "points" => comments.OrderByDescending(c => c.Point),
                "category" => comments.OrderBy(c => c.Category.Name),
                _ => comments.OrderByDescending(c => c.CreateDate)
            };

            ViewBag.Categories = _categoryService.GetAllCategories().Where(c => c.Status == Status.Active);
            return View(comments.ToList());
        }

        [HttpGet]
        public IActionResult AddComment()
        {

            return View(new Comment { CreateDate = DateTime.Now });
        }

        [HttpPost]
        public IActionResult AddComment(CommentApp_Cores.Models.Comment comment)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    _commentService.CreateComment(comment);
                    TempData["SuccessMessage"] = "Yorum baþarýyla eklendi!";
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                }
                return RedirectToAction("Index"); 
            }
            var comments = _commentService.GetAllComments().Where(c => c.Status == Status.Active);
            return View("Index", comments); 
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}