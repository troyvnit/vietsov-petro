using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.Domain.Commands;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Model.Entities;
using System;
using VietSovPetro.CommandProcessor.Commands;
using System.Collections.Generic;

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
            var articlecategories = new List<ArticleCategory>();
            foreach (Guid acID in command.ArticleCategoryIDs)
            {
                articlecategories.Add(articleCategoryRepository.GetById(acID));
            }
            var article = new Article
            {
                ArticleID = command.ArticleID,
                Author = command.Author,
                Content = command.Content,
                Description = command.Description,
                ImageUrl = command.ImageUrl,
                IsNew = command.IsNew,
                IsPublished = command.IsPublished,
                Title = command.Title,
                IsDeleted = false,
                ActicleNumber = 1,
                ArticleCategories = articlecategories
            };
            if (article.ArticleID == Guid.Empty)
            {
                article.ArticleID = Guid.NewGuid();
                articleRepository.Add(article);
            }
            else
            {
                articleRepository.Update(article);
            }
            unitOfWork.Commit();
            return new CommandResult(true);
        }
    }
}
