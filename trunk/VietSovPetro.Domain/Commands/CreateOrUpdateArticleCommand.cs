using VietSovPetro.CommandProcessor.Commands.ICommands;
using System;
using System.Collections.Generic;

namespace VietSovPetro.Domain.Commands
{
    public class CreateOrUpdateArticleCommand : ICommand
    {
        public CreateOrUpdateArticleCommand(Guid ArticleID, string Title, string Description,
            string Content, string Author, string ImageUrl, bool IsPublished, bool IsNew, List<Guid> ArticleCategoryIDs)
        {
            this.ArticleID = ArticleID;
            this.Author = Author;
            this.Content = Content;
            this.Description = Description;
            this.ImageUrl = ImageUrl;
            this.IsNew = IsNew;
            this.IsPublished = IsPublished;
            this.Title = Title;
            this.ArticleCategoryIDs = ArticleCategoryIDs;
        }
        public Guid ArticleID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public List<Guid> ArticleCategoryIDs { get; set; }
    }
}
