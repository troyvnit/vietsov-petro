using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietSovPetro.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private VietSovPetroDataContext dataContext;
        public VietSovPetroDataContext Get()
        {
            return dataContext ?? (dataContext = new VietSovPetroDataContext());
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
