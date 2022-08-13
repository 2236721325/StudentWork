using Shared.BaseRepositorys;
using Shared.BaseServices;
using User_DLL.Models;
using User_Service.IServices;

namespace User_Service.Services
{
    public class CheckRecordService : BaseService<CheckRecord>, ICheckRecordService
    {
        public CheckRecordService(IBaseRepository<CheckRecord> repository) : base(repository)
        {

        }
    }
}
