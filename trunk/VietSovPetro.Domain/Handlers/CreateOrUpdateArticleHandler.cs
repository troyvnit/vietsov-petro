using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.Domain.Commands;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Model.Entities;
using System;
using VietSovPetro.CommandProcessor.Commands;
using System.Collections.Generic;
using System.Linq;

namespace VietSovPetro.Domain.Handlers
{
    public class CreateOrUpdateArticleHandler : ICommandHandler<CreateOrUpdateArticleCommand>
    {
        private readonly IArticleRepository articleRepository;
        private readonly IArticleCategoryRepository articleCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CreateOrUpdateArticleHandler(IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.articleRepository = articleRepository;
            this.articleCategoryRepository = articleCategoryRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(CreateOrUpdateArticleCommand command)
        {
            Guid ID;
            if (articleRepository.GetById(command.ArticleID) == null)
            {
                var article = new Article
                    {
                        Author = command.Author,
                        Content = command.Content,
                        Description = command.Description,
                        ImageUrl = command.ImageUrl,
                        IsNew = command.IsNew,
                        IsPublished = command.IsPublished,
                        Title = command.Title,
                        IsDeleted = false,
                        ActicleNumber = 1,
                        OrderID = command.OrderID,
                        RoomID = command.RoomID,
                        LanguageCode = command.LanguageCode, 
                        ArticleCategories = new List<ArticleCategory>(), 
                        ArticleID = command.ArticleID == Guid.Empty ? Guid.NewGuid() : command.ArticleID
                    };
                foreach (var articlecategory in command.ArticleCategoryIDs.Select(acID => articleCategoryRepository.GetById(acID)))
                {
                    article.ArticleCategories.Add(articlecategory);
                }
                articleRepository.Add(article);
                ID = article.ArticleID;
            }
            else
            {
                var article = articleRepository.GetById(command.ArticleID);
                article.Author = command.Author;
                article.Content = command.Content;
                article.Description = command.Description;
                article.ImageUrl = command.ImageUrl;
                article.IsNew = command.IsNew;
                article.IsPublished = command.IsPublished;
                article.Title = command.Title;
                article.IsDeleted = false;
                article.ActicleNumber = 1;
                article.OrderID = command.OrderID;
                article.RoomID = command.RoomID;
                article.LanguageCode = command.LanguageCode;
                var articlecategories = command.ArticleCategoryIDs.Select(acID => articleCategoryRepository.GetById(acID)).ToList();
                var deleteCats = article.ArticleCategories.Where(ac => !command.ArticleCategoryIDs.Contains(ac.ArticleCategoryID)).ToList();
                var addCats = articlecategories.Where(ac => !article.ArticleCategories.Select(a => a.ArticleCategoryID).Contains(ac.ArticleCategoryID)).ToList();

                foreach (var deleteCat in deleteCats)
                {
                    article.ArticleCategories.Remove(deleteCat);
                }

                foreach (var addCat in addCats)
                {
                    article.ArticleCategories.Add(addCat);
                }
                articleRepository.Update(article);
                ID = article.ArticleID;
            }
            unitOfWork.Commit();
            return new CommandResult(true, ID);
        }
    }
}
