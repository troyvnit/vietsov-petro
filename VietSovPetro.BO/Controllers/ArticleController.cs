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
            return Json(articleCategoryRepository.GetAll().Where(a => a.IsDeleted != true), JsonRequestBehavior.AllowGet);
        }    
        [HttpPost]
        public void CreateOrUpdateArticleCategories(string models)
        {
            ArticleCategoryViewModel articleCategory = JsonConvert.DeserializeObject<List<ArticleCategoryViewModel>>(models).FirstOrDefault();
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<ArticleCategoryViewModel, CreateOrUpdateArticleCategoryCommand>(articleCategory);
                IEnumerable<ValidationResult> errors = commandBus.Validate(command);
                if (ModelState.IsValid)
                {
                    var result = commandBus.Submit(command);
                }
            }
        }
        [HttpPost]
        public void DeleteArticleCategories(string models)
        {
            ArticleCategoryViewModel articleCategory = JsonConvert.DeserializeObject<List<ArticleCategoryViewModel>>(models).FirstOrDefault();
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<ArticleCategoryViewModel, DeleteArticleCategoryCommand>(articleCategory);
                var result = commandBus.Submit(command);
            }
        }
        [HttpPost]
        public JsonResult GetArticles()
        {
            return Json(articleRepository.GetAll().Where(a => a.IsDeleted != true), JsonRequestBehavior.AllowGet);
        } 
    }
}
