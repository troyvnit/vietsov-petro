using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EFMVCPycoNet.Domain.Entities;

namespace EFMVCPycoNet.Data
{
    public class EFMVCPycoNetDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
