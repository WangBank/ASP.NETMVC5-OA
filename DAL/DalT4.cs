


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
    public partial class FileInfoDal:BaseDal<FileInfo>,IFileInfoDal
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
    public partial class WF_ItemDal:BaseDal<WF_Item>,IWF_ItemDal
    {
    } 
    public partial class WF_StepDal:BaseDal<WF_Step>,IWF_StepDal
    {
    } 
    public partial class WF_TempDal:BaseDal<WF_Temp>,IWF_TempDal
    {
    } 


}
