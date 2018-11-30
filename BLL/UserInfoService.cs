using DAL;
using DALFactory;
using IBLL;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Params;

namespace BLL
{
    public partial class UserInfoService : BaseServices<UserInfo>, IUserInfoService
    {

        //多条件查询
        public IQueryable<UserInfo> LoadPageData(UserQueryParam userQueryParam)
        {
            short normalFlag = (short )Model.Enums.DelFlagEnum.Normal;
            var temp = DbSession.UserInfoDal.GetEntities(u=>u.DelFlag==normalFlag);

            //过滤
            if (!string.IsNullOrEmpty(userQueryParam.SchName))
            {
                temp = temp.Where(u => u.UName.Contains(userQueryParam.SchName)).AsQueryable();
            }

            //过滤
            if (!string.IsNullOrEmpty(userQueryParam.SchRemark))
            {
                temp = temp.Where(u => u.Remark.Contains(userQueryParam.SchRemark)).AsQueryable();
            }

            userQueryParam.Total = temp.Count();


            //分页
            return temp.OrderBy(u => u.ID).Skip(userQueryParam.PageSize*(userQueryParam.PageIndex - 1)).Take(userQueryParam.PageSize).AsQueryable();
        }
    }
}
