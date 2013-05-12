using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Model.Entities;
using VietSovPetro.Data.Repositories.IRepositories;
using System.Data.SqlClient;

namespace VietSovPetro.Data.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
        public override void Update(Book entity)
        {
            var BookIDParameter = new SqlParameter("BookID", entity.BookID);
            var NameParameter = new SqlParameter("Name", entity.Name);
            var EmailParameter = new SqlParameter("Email", entity.Email);
            var RoomParameter = new SqlParameter("Room", entity.Room);
            var BeginParameter = new SqlParameter("Begin", entity.Begin);
            var EndParameter = new SqlParameter("End", entity.End);
            var TimeParameter = new SqlParameter("Time", entity.Time);
            var GuestQuantityParameter = new SqlParameter("GuestQuantity", entity.GuestQuantity);
            var MeetingTypeParameter = new SqlParameter("MeetingType", entity.MeetingType);
            var PriceParameter = new SqlParameter("Price", entity.Price);
            var MessageParameter = new SqlParameter("Message", entity.Message);
            var UserCardNameParameter = new SqlParameter("UserCardName", entity.UserCardName);
            var UserCardNumberParameter = new SqlParameter("UserCardNumber", entity.UserCardNumber);
            var UserCardTypeParameter = new SqlParameter("UserCardType", entity.UserCardType);
            var DueDateParameter = new SqlParameter("DueDate", entity.DueDate);
            DataContext.Database.ExecuteSqlCommand("dbo.CreateOrUpdateBooks @BookID, @Name, @Email, @Room, @Begin, @End, @Time, @GuestQuantity, @MeetingType, @Price, @Message, @UserCardName, @UserCardNumber, @UserCardType, @DueDate",
            BookIDParameter, NameParameter, EmailParameter, RoomParameter, BeginParameter, EndParameter, TimeParameter,
            GuestQuantityParameter, MeetingTypeParameter, PriceParameter, MessageParameter, UserCardNameParameter, UserCardNumberParameter,
            UserCardTypeParameter, DueDateParameter);
        }
    }
}
