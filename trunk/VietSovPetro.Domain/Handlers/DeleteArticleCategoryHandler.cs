using System;
using VietSovPetro.CommandProcessor.Commands;
using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Domain.Commands;

namespace VietSovPetro.Domain.Handlers
{
    public class DeleteArticleCategoryHandler : ICommandHandler<DeleteArticleCategoryCommand>
    {
        private readonly IArticleCategoryRepository articleCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteArticleCategoryHandler(IArticleCategoryRepository articleCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.articleCategoryRepository = articleCategoryRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(DeleteArticleCategoryCommand command)
        {
            var ID = Guid.Empty;
            var articleCategory = articleCategoryRepository.GetById(command.ArticleCategoryID);
            articleCategory.IsDeleted = true;
            articleCategoryRepository.Update(articleCategory);
            ID = articleCategory.ArticleCategoryID;
            unitOfWork.Commit();
            return new CommandResult(true, ID);
        }
    }
}
