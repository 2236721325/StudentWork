using Microsoft.EntityFrameworkCore;
using Shared.BaseRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_DLL.Contexts;
using User_DLL.IRepositorys;
using User_DLL.Models;

namespace User_DLL.Repositorys
{
    public class UserRepository : BaseRepository<CheckRecord>, IUserRepository
    {
        public UserRepository(DbContext context):base(context)
        {

        }
    }
}
