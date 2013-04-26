using System;
using VietSovPetro.CommandProcessor.Commands.ICommands;

namespace VietSovPetro.Domain.Commands
{
    public class DeleteArticleCommand : ICommand
    {
        public Guid ArticleID;
        public bool IsDeleted;
    }
}
