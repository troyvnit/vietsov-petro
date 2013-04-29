using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.Domain.Commands;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Model.Entities;
using System;
using VietSovPetro.CommandProcessor.Commands;

namespace VietSovPetro.Domain.Handlers
{
    public class CreateOrUpdateArticleCategoryHandler : ICommandHandler<CreateOrUpdateArticleCategoryCommand>
    {
        private readonly IArticleCategoryRepository articleCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CreateOrUpdateArticleCategoryHandler(IArticleCategoryRepository articleCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.articleCategoryRepository = articleCategoryRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(CreateOrUpdateArticleCategoryCommand command)
        {
            Guid ID;
            var articleCategory = new ArticleCategory
            {
                ArticleCategoryID = command.ArticleCategoryId,
                ArticleCategoryName = command.ArticleCategoryName,
                ArticleCategoryType = command.ArticleCategoryType,
                Description = command.Description,
                LanguageCode = command.LanguageCode
            };
            if (articleCategory.ArticleCategoryID == Guid.Empty)
            {
                articleCategory.ArticleCategoryID = Guid.NewGuid();
                articleCategoryRepository.Add(articleCategory);
                ID = articleCategory.ArticleCategoryID;
            }
            else
            {
                articleCategoryRepository.Update(articleCategory);
                ID = articleCategory.ArticleCategoryID;
            }
            unitOfWork.Commit();
            return new CommandResult(true, ID);
        }
    }
}
