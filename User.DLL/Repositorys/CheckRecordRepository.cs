using Microsoft.EntityFrameworkCore;
using Shared.BaseRepositorys;
using User_DLL.Contexts;
using User_DLL.IRepositorys;
using User_DLL.Models;

namespace User_DLL.Repositorys
{
    public class CheckRecordRepository : BaseRepository<CheckRecord>, ICheckRecordRepository
    {
        public CheckRecordRepository(DbContext context) : base(context)
        {

        }
    }
}
