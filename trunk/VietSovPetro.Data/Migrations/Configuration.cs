using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace VietSovPetro.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<VietSovPetro.Data.VietSovPetroDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VietSovPetro.Data.VietSovPetroDataContext context)
        {
            
        }
    }
}
