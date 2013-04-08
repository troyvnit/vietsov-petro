using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace EFMVCPycoNet.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EFMVCPycoNet.Data.EFMVCPycoNetDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EFMVCPycoNet.Data.EFMVCPycoNetDataContext context)
        {
            
        }
    }
}
