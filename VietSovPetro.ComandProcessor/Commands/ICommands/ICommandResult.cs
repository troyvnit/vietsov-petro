﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietSovPetro.CommandProcessor.Commands.ICommands
{
    public interface ICommandResult
    {
        bool Success { get; }
        Guid ID { get; }
    }
}
