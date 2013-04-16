using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.CommandProcessor.Commands;
using VietSovPetro.Core.Common;
using System.Collections.Generic;
namespace VietSovPetro.CommandProcessor.Dispatcher
{
    public interface ICommandBus
    {
        ICommandResult Submit<TCommand>(TCommand command) where TCommand: ICommand;
        IEnumerable<ValidationResult> Validate<TCommand>(TCommand command) where TCommand : ICommand;
    }
}

