using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietSovPetro.CommandProcessor.Commands;
using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.Data.Repositories.IRepositories;
using VietSovPetro.Domain.Commands;
using VietSovPetro.Model.Entities;

namespace VietSovPetro.Domain.Handlers
{
    public class CanAddArticle : IValidationHandler<CreateOrUpdateArticleCommand>
    {
        private readonly IArticleRepository articleRepository;
        public CanAddArticle(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
        public IEnumerable<ValidationResult> Validate(CreateOrUpdateArticleCommand command)
        {
            Article isArticleExists = null;
            if (command.ArticleID == Guid.Empty)
                isArticleExists = articleRepository.Get(c => c.Title == command.Title);
            else
                isArticleExists = articleRepository.Get(c => c.Title == command.Title && c.ArticleID != command.ArticleID);
            if (isArticleExists != null)
            {
                yield return new ValidationResult("Title", "Existed");
            }
        }
    }
}
