using System;
using VietSovPetro.CommandProcessor.Commands.ICommands;

namespace VietSovPetro.Domain.Commands
{
    public class DeleteArticleCategoryCommand : ICommand
    {
        public Guid ArticleCategoryID;
        public bool IsDeleted;
    }
}
