using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietSovPetro.Data.Infrastructure
{
    public interface IDatabaseFactory
    {
        VietSovPetroDataContext Get();
    }
}
