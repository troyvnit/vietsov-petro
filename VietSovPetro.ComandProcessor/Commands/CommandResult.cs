﻿using System;
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
        public Guid ID { get; protected set; }
        public CommandResult(bool success, Guid ID)
        {
            this.Success = success;
            this.ID = ID;
        }
    }
}
