using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{   
    public partial class ActionInfoDal:BaseDal<ActionInfo>,IActionInfoDal
    {
    } 
    public partial class BooksDal:BaseDal<Books>,IBooksDal
    {
    } 
    public partial class DepartmentDal:BaseDal<Department>,IDepartmentDal
    {
    } 
    public partial class KeyWordsRankDal:BaseDal<KeyWordsRank>,IKeyWordsRankDal
    {
    } 
    public partial class R_UserInfo_ActionInfoDal:BaseDal<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoDal
    {
    } 
    public partial class RoleInfoDal:BaseDal<RoleInfo>,IRoleInfoDal
    {
    } 
    public partial class SearchDetailsDal:BaseDal<SearchDetails>,ISearchDetailsDal
    {
    } 
    public partial class UserInfoDal:BaseDal<UserInfo>,IUserInfoDal
    {
    } 

}
