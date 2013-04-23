using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Model.Entities;
using VietSovPetro.Data.Repositories.IRepositories;

namespace VietSovPetro.Data.Repositories
{
    public class RoomTypeRepository : RepositoryBase<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
