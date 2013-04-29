using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using VietSovPetro.Model.Entities;
using System.Data.Objects;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace VietSovPetro.Data
{
    public class VietSovPetroDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomProperty> RoomProperties { get; set; }
        public virtual void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }

                throw;  // You can also choose to handle the exception here...
            }
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
