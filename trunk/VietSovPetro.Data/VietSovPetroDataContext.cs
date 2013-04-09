using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VietSovPetro.Domain.Entities;

namespace VietSovPetro.Data
{
    public class VietSovPetroDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Price> Prices { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
