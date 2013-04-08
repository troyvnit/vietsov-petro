using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMVCPycoNet.Data.Infrastructure
{
    public interface IDatabaseFactory
    {
        EFMVCPycoNetDataContext Get();
    }
}
