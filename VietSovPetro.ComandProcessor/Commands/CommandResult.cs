using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietSovPetro.CommandProcessor.Commands.ICommands;

namespace VietSovPetro.CommandProcessor.Commands
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; protected set; }
        public CommandResult(bool success)
        {
            this.Success = success;
        }
    }
}
