using VietSovPetro.CommandProcessor.Commands.ICommands;
using System;

namespace VietSovPetro.Domain.Commands
{
    public class CreateOrUpdateArticleCategoryCommand : ICommand
    {
        public CreateOrUpdateArticleCategoryCommand(Guid ArticleCategoryId, string ArticleCategoryName,
            string ArticleCategoryType, string Description, string LanguageCode)
        {
            this.ArticleCategoryId = ArticleCategoryId;
            this.ArticleCategoryName = ArticleCategoryName;
            this.ArticleCategoryType = ArticleCategoryType;
            this.Description = Description;
            this.LanguageCode = LanguageCode;
        }
        public Guid ArticleCategoryId { get; set; }
        public string ArticleCategoryName { get; set; }
        public string ArticleCategoryType { get; set; }
        public string Description { get; set; }
        public string LanguageCode { get; set; }
    }
}
