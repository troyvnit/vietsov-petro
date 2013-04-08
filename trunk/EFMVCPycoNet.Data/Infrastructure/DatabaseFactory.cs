using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMVCPycoNet.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private EFMVCPycoNetDataContext dataContext;
        public EFMVCPycoNetDataContext Get()
        {
            return dataContext ?? (dataContext = new EFMVCPycoNetDataContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
            }
        } 
    }
}
