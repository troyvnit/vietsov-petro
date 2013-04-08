﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMVCPycoNet.ComandProcessor.Commands.ICommands
{
    public interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        IEnumerable<ValidationResult> Validate(TCommand command);
    }
}
