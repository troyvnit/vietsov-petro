using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Model.Entities;
using VietSovPetro.Data.Repositories.IRepositories;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.SqlClient;

namespace VietSovPetro.Data.Repositories
{
    public class RoomPropertyRoomRepository : RepositoryBase<RoomPropertyRooms>, IRoomPropertyRoomRepository
    {
        public RoomPropertyRoomRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
        public override void Update(RoomPropertyRooms entity)
        {
            var RoomIDParameter = new SqlParameter("RoomID", entity.RoomID);
            var RoomPropertyIDParameter = new SqlParameter("RoomPropertyID", entity.RoomPropertyID);
            var StringValueParameter = new SqlParameter("StringValue", entity.RoomPropertyStringValue != null ? entity.RoomPropertyStringValue : "");
            var NumberValueParameter = new SqlParameter("NumberValue", entity.RoomPropertyNumberValue);
            var IsNewParameter = new SqlParameter("IsNew", entity.IsNew);
            var IsPublishedParameter = new SqlParameter("IsPublished", entity.IsPublished);
            DataContext.Database.ExecuteSqlCommand("dbo.CreateOrUpdateRoomPropertyRooms @RoomID, @RoomPropertyID, @StringValue, @NumberValue, @IsNew, @IsPublished", RoomIDParameter, RoomPropertyIDParameter, StringValueParameter, NumberValueParameter, IsNewParameter, IsPublishedParameter);
        }
    }
}
