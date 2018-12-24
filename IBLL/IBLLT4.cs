

 


using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{

   
    
	    public partial interface IActionInfoService:IBaseService<ActionInfo>
    {
        bool SetRole(int actionid, List<int> roleIds);
    }
    
	    public partial interface IBooksService:IBaseService<Books>
    {
	}
    
	    public partial interface IDepartmentService:IBaseService<Department>
    {
	}
    
	    public partial interface IFileInfoService:IBaseService<FileInfo>
    {
	}
    
	    public partial interface IKeyWordsRankService:IBaseService<KeyWordsRank>
    {
	}
    
	    public partial interface IR_UserInfo_ActionInfoService:IBaseService<R_UserInfo_ActionInfo>
    {
	}
    
	    public partial interface IRoleInfoService:IBaseService<RoleInfo>
    {
	}
    
	    public partial interface ISearchDetailsService:IBaseService<SearchDetails>
    {
	}
    
	    public partial interface IUserInfoService:IBaseService<UserInfo>
    {
	}
    
	    public partial interface IWF_ItemService:IBaseService<WF_Item>
    {
	}
    
	    public partial interface IWF_StepService:IBaseService<WF_Step>
    {
	}
    
	    public partial interface IWF_TempService:IBaseService<WF_Temp>
    {
	}


}
