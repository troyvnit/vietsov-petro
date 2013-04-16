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
    public class CanAddArticleCategory : IValidationHandler<CreateOrUpdateArticleCategoryCommand>
    {
        private readonly IArticleCategoryRepository articleCategoryRepository;
        public CanAddArticleCategory(IArticleCategoryRepository articleCategoryRepository)
        {
            this.articleCategoryRepository = articleCategoryRepository;
        }
        public IEnumerable<ValidationResult> Validate(CreateOrUpdateArticleCategoryCommand command)
        {
            ArticleCategory isArticleCategoryExists = null;
            if (command.ArticleCategoryId == Guid.Empty)
                isArticleCategoryExists = articleCategoryRepository.Get(c => c.ArticleCategoryName == command.ArticleCategoryName);
            else
                isArticleCategoryExists = articleCategoryRepository.Get(c => c.ArticleCategoryName == command.ArticleCategoryName && c.ArticleCategoryID != command.ArticleCategoryId);
            if (isArticleCategoryExists != null)
            {
                yield return new ValidationResult("ArticleCategoryName", "Existed");
            }
        }
    }
}
