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
            var RoomParameter = new SqlParameter("RoomID", entity.Room.RoomID);
            var BeginParameter = new SqlParameter("Begin", entity.Begin);
            var EndParameter = new SqlParameter("End", entity.End);
            var TimeParameter = new SqlParameter("Time", entity.Time);
            var GuestQuantityParameter = new SqlParameter("GuestQuantity", entity.GuestQuantity);
            var MeetingTypeParameter = entity.MeetingType != null ? new SqlParameter("MeetingType", entity.MeetingType) : new SqlParameter("MeetingType", DBNull.Value);
            var PriceParameter = new SqlParameter("Price", entity.Price);
            var MessageParameter = entity.Message != null ? new SqlParameter("Message", entity.Message) : new SqlParameter("Message", DBNull.Value);
            var UserCardNameParameter = entity.UserCardName != null ? new SqlParameter("UserCardName", entity.UserCardName) : new SqlParameter("UserCardName", DBNull.Value);
            var UserCardNumberParameter = entity.UserCardNumber != null ? new SqlParameter("UserCardNumber", entity.UserCardNumber) : new SqlParameter("UserCardNumber", DBNull.Value);
            var UserCardTypeParameter = entity.UserCardType != null ? new SqlParameter("UserCardType", entity.UserCardType) : new SqlParameter("UserCardType", DBNull.Value);
            var DueDateParameter = entity.DueDate != null ? new SqlParameter("DueDate", entity.DueDate) : new SqlParameter("DueDate", DBNull.Value);
            DataContext.Database.ExecuteSqlCommand("dbo.CreateOrUpdateBooks @BookID, @Name, @Email, @RoomID, @Begin, @End, @Time, @GuestQuantity, @MeetingType, @Price, @Message, @UserCardName, @UserCardNumber, @UserCardType, @DueDate",
            BookIDParameter, NameParameter, EmailParameter, RoomParameter, BeginParameter, EndParameter, TimeParameter,
            GuestQuantityParameter, MeetingTypeParameter, PriceParameter, MessageParameter, UserCardNameParameter, UserCardNumberParameter,
            UserCardTypeParameter, DueDateParameter);
        }
    }
}
