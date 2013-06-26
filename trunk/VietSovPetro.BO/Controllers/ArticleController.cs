﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Model.Entities;
using VietSovPetro.CommandProcessor.Dispatcher;
using VietSovPetro.Domain.Commands;
using AutoMapper;
using Newtonsoft.Json;
using VietSovPetro.BO.ViewModels;

namespace VietSovPetro.BO.Controllers
{
    using System;

    [Authorize]
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
            if (Session["VietSovPetroAdmin"] != null)
            {
                return View("~/Views/Admin/Article/Index.cshtml");
            }
            return RedirectToAction("Login", "Account"); 
        }
        [HttpPost]
        public JsonResult GetArticleCategories()
        {
            var articlecategories = articleCategoryRepository.GetAll().Where(a => a.IsDeleted != true).Select(Mapper.Map<ArticleCategory, ArticleCategoryViewModel>).ToList();
            return Json(articlecategories.OrderBy(a => a.Description), JsonRequestBehavior.AllowGet);
        }    
        [HttpPost]
        public ActionResult CreateOrUpdateArticleCategories(string models)
        {
            var articleCategories = JsonConvert.DeserializeObject<List<ArticleCategoryViewModel>>(models);
            if (ModelState.IsValid)
            {
                foreach (var articleCategory in articleCategories)
                {
                    var command = Mapper.Map<ArticleCategoryViewModel, CreateOrUpdateArticleCategoryCommand>(articleCategory);
                    commandBus.Validate(command);
                    if (ModelState.IsValid)
                    {
                        commandBus.Submit(command);
                    }
                }
                return Json(articleCategories, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteArticleCategories(string models)
        {
             var articleCategories = JsonConvert.DeserializeObject<List<ArticleCategoryViewModel>>(models);
            if (ModelState.IsValid)
            {
                foreach (var command in articleCategories.Select(Mapper.Map<ArticleCategoryViewModel, DeleteArticleCategoryCommand>))
                {
                    commandBus.Submit(command);
                }
                return Json(articleCategories, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetArticles()
        {
            var articles = new List<ArticleViewModel>();
            foreach(var article in articleRepository.GetAll().Where(a => a.IsDeleted != true))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articlevm.Room = Mapper.Map<Room, RoomViewModel>(article.Room) ?? new RoomViewModel();
                articles.Add(articlevm);
            }
            return Json(articles, JsonRequestBehavior.AllowGet);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CreateOrUpdateArticles(string models)
        {
            var articles = JsonConvert.DeserializeObject<List<ArticleViewModel>>(models);
            if (ModelState.IsValid)
            {
                foreach (var article in articles)
                {
                    article.RoomID = article.Room.RoomID;
                    var command = Mapper.Map<ArticleViewModel, CreateOrUpdateArticleCommand>(article);
                    command.RoomID = command.RoomID == Guid.Empty ? null : command.RoomID;
                    commandBus.Validate(command);
                    if (!ModelState.IsValid)
                    {
                        continue;
                    }
                    var result = commandBus.Submit(command);
                    article.ArticleID = result.ID;
                }
                return Json(articles, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DeleteArticles(string models)
        {
            var articles = JsonConvert.DeserializeObject<List<DeleteArticle>>(models);
            if (ModelState.IsValid)
            {
                foreach (var command in articles.Select(Mapper.Map<DeleteArticle, DeleteArticleCommand>))
                {
                    commandBus.Submit(command);
                }
                return Json(articles, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
    public class DeleteArticle
    {
        public Guid ArticleID;
        public bool IsDeleted;
    }
}
