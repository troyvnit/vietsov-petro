using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VietSovPetro.Data;
using VietSovPetro.Data.Repositories;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Model.Entities;
using VietSovPetro.CommandProcessor.Dispatcher;
using VietSovPetro.Domain.Commands;
using AutoMapper;
using Newtonsoft.Json;
using VietSovPetro.BO.ViewModels;
using VietSovPetro.CommandProcessor.Commands;

namespace VietSovPetro.BO.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/
        private readonly IArticleCategoryRepository articleCategoryRepository;
        private readonly IArticleRepository articleRepository;
        private readonly ICommandBus commandBus;
        public ArticleController(IArticleCategoryRepository articleCategoryRepository, ICommandBus commandBus, IArticleRepository articleRepository)
        {
            this.articleCategoryRepository = articleCategoryRepository;
            this.commandBus = commandBus;
            this.articleRepository = articleRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetArticleCategories()
        {
            var articlecategories = new List<ArticleCategoryViewModel>(); 
            foreach (ArticleCategory articlecategory in articleCategoryRepository.GetAll().Where(a => a.IsDeleted != true))
            {
                articlecategories.Add(Mapper.Map<ArticleCategory, ArticleCategoryViewModel>(articlecategory));
            }
            return Json(articlecategories, JsonRequestBehavior.AllowGet);
        }    
        [HttpPost]
        public ActionResult CreateOrUpdateArticleCategories(string models)
        {
            ArticleCategoryViewModel articleCategory = JsonConvert.DeserializeObject<List<ArticleCategoryViewModel>>(models).FirstOrDefault();
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<ArticleCategoryViewModel, CreateOrUpdateArticleCategoryCommand>(articleCategory);
                IEnumerable<ValidationResult> errors = commandBus.Validate(command);
                if (ModelState.IsValid)
                {
                    var result = commandBus.Submit(command);
                    return Json(command, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteArticleCategories(string models)
        {
            ArticleCategoryViewModel articleCategory = JsonConvert.DeserializeObject<List<ArticleCategoryViewModel>>(models).FirstOrDefault();
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<ArticleCategoryViewModel, DeleteArticleCategoryCommand>(articleCategory);
                var result = commandBus.Submit(command);
                return Json(command, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetArticles()
        {
            var articles = new List<ArticleViewModel>();
            foreach(Article article in articleRepository.GetAll().Where(a => a.IsDeleted != true))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            return Json(articles, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateOrUpdateArticles(string models)
        {
            ArticleViewModel articleCategory = JsonConvert.DeserializeObject<List<ArticleViewModel>>(models).FirstOrDefault();
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<ArticleViewModel, CreateOrUpdateArticleCommand>(articleCategory);
                IEnumerable<ValidationResult> errors = commandBus.Validate(command);
                if (ModelState.IsValid)
                {
                    var result = commandBus.Submit(command);
                    return Json(command, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
