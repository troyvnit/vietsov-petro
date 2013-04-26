using System;
using VietSovPetro.CommandProcessor.Commands;
using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Domain.Commands;

namespace VietSovPetro.Domain.Handlers
{
    public class DeleteArticleHandler : ICommandHandler<DeleteArticleCommand>
    {
        private readonly IArticleRepository articleRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteArticleHandler(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            this.articleRepository = articleRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(DeleteArticleCommand command)
        {
            var ID = Guid.Empty;
            var article = articleRepository.GetById(command.ArticleID);
            article.IsDeleted = true;
            articleRepository.Update(article);
            ID = article.ArticleID;
            unitOfWork.Commit();
            return new CommandResult(true, ID);
        }
    }
}
