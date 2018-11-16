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
	}
    
	    public partial interface IBooksService:IBaseService<Books>
    {
	}
    
	    public partial interface IDepartmentService:IBaseService<Department>
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

}
