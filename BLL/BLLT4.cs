 

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

   
    
	    public partial class ActionInfoService : BaseServices<ActionInfo>,IActionInfoService
    {
        public override void SetCurrent()
        {
            CurrentDal = this.DbSession.ActionInfoDal;
        }
		}
    
	    public partial class BooksService : BaseServices<Books>,IBooksService
    {
        public override void SetCurrent()
        {
            CurrentDal = this.DbSession.BooksDal;
        }
		}
    
	    public partial class DepartmentService : BaseServices<Department>,IDepartmentService
    {
        public override void SetCurrent()
        {
            CurrentDal = this.DbSession.DepartmentDal;
        }
		}
    
	    public partial class KeyWordsRankService : BaseServices<KeyWordsRank>,IKeyWordsRankService
    {
        public override void SetCurrent()
        {
            CurrentDal = this.DbSession.KeyWordsRankDal;
        }
		}
    
	    public partial class R_UserInfo_ActionInfoService : BaseServices<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoService
    {
        public override void SetCurrent()
        {
            CurrentDal = this.DbSession.R_UserInfo_ActionInfoDal;
        }
		}
    
	    public partial class RoleInfoService : BaseServices<RoleInfo>,IRoleInfoService
    {
        public override void SetCurrent()
        {
            CurrentDal = this.DbSession.RoleInfoDal;
        }
		}
    
	    public partial class SearchDetailsService : BaseServices<SearchDetails>,ISearchDetailsService
    {
        public override void SetCurrent()
        {
            CurrentDal = this.DbSession.SearchDetailsDal;
        }
		}
    
	    public partial class UserInfoService : BaseServices<UserInfo>,IUserInfoService
    {
        public override void SetCurrent()
        {
            CurrentDal = this.DbSession.UserInfoDal;
        }
		}

}
