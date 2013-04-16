using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using VietSovPetro.Model.Entities;
using System.Data.Objects;

namespace VietSovPetro.Data
{
    public class VietSovPetroDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomDetail> RoomDetails { get; set; }
        public DbSet<RoomProperty> RoomProperties { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantDetail> RestaurantDetails { get; set; }
        public DbSet<RestaurantMenu> RestaurantMenus { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
        public virtual ObjectResult<ArticleCategory> GetAllArticleCategoriesPaged(int page, int pageSize)
        {
            ((IObjectContextAdapter)this).ObjectContext.MetadataWorkspace.LoadFromAssembly(typeof(ArticleCategory).Assembly);
            var pageParameter = new ObjectParameter("page", page);
            var pageSizeParameter = new ObjectParameter("pageSize", pageSize);
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ArticleCategory>("GetAllArticleCategoriesPaged", pageParameter, pageSizeParameter);
        }
    }
}
