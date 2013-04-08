using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFMVCPycoNet.Data.Infrastructure;
using EFMVCPycoNet.Domain.Entities;
using EFMVCPycoNet.Data.Repositories.IRepositories;

namespace EFMVCPycoNet.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { 
        }
    }
}
