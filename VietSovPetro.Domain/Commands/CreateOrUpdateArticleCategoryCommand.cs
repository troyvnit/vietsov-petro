using VietSovPetro.CommandProcessor.Commands.ICommands;
using System;

namespace VietSovPetro.Domain.Commands
{
    public class CreateOrUpdateArticleCategoryCommand : ICommand
    {
        public CreateOrUpdateArticleCategoryCommand(Guid ArticleCategoryId, string ArticleCategoryName, string ArticleCategoryType, string Description)
        {
            this.ArticleCategoryId = ArticleCategoryId;
            this.ArticleCategoryName = ArticleCategoryName;
            this.ArticleCategoryType = ArticleCategoryType;
            this.Description = Description;
        }
        public Guid ArticleCategoryId { get; set; }
        public string ArticleCategoryName { get; set; }
        public string ArticleCategoryType { get; set; }
        public string Description { get; set; }
    }
}
