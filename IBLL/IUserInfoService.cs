using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public partial interface IUserInfoService:IBaseService<UserInfo>
    {
        //多条件查询
        IQueryable<UserInfo> LoadPageData(Model.Params.UserQueryParam userQueryParam);

        bool SetRole(int userid, List<int> roleIds);
    }
}
