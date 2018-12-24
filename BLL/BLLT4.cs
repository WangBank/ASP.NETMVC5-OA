

 


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

        public bool SetRole(int actionid, List<int> roleIds)
        {
            var action = DbSession.ActionInfoDal.GetEntities(u => u.ID == actionid).FirstOrDefault();
            action.RoleInfo.Clear();
            var allroel = DbSession.RoleInfoDal.GetEntities(r => roleIds.Contains(r.ID));

            foreach (var item in allroel)
            {
                action.RoleInfo.Add(item);
            }

            return DbSession.SaveChanges() > 0;
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
    
	    public partial class FileInfoService : BaseServices<FileInfo>,IFileInfoService
    {
        public override void SetCurrent()
        {
            CurrentDal = this.DbSession.FileInfoDal;
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
    
	    public partial class WF_ItemService : BaseServices<WF_Item>,IWF_ItemService
    {
        public override void SetCurrent()
        {
            CurrentDal = this.DbSession.WF_ItemDal;
        }
		}
    
	    public partial class WF_StepService : BaseServices<WF_Step>,IWF_StepService
    {
        public override void SetCurrent()
        {
            CurrentDal = this.DbSession.WF_StepDal;
        }
		}
    
	    public partial class WF_TempService : BaseServices<WF_Temp>,IWF_TempService
    {
        public override void SetCurrent()
        {
            CurrentDal = this.DbSession.WF_TempDal;
        }
		}


}
