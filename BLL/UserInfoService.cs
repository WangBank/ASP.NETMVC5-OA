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

namespace BLL
{
    public partial class UserInfoService : BaseServices<UserInfo>,IUserInfoService
    {
        //public override void SetCurrent()
        //{
        //    CurrentDal = this.DbSession.userInfoDal;
        //}

        
    }
}
