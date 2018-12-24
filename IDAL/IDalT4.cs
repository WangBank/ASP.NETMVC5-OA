

 


using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
   
    public partial interface IActionInfoDal:IBaseDal<ActionInfo> 
    {
    } 
    public partial interface IBooksDal:IBaseDal<Books> 
    {
    } 
    public partial interface IDepartmentDal:IBaseDal<Department> 
    {
    } 
    public partial interface IFileInfoDal:IBaseDal<FileInfo> 
    {
    } 
    public partial interface IKeyWordsRankDal:IBaseDal<KeyWordsRank> 
    {
    } 
    public partial interface IR_UserInfo_ActionInfoDal:IBaseDal<R_UserInfo_ActionInfo> 
    {
    } 
    public partial interface IRoleInfoDal:IBaseDal<RoleInfo> 
    {
    } 
    public partial interface ISearchDetailsDal:IBaseDal<SearchDetails> 
    {
    } 
    public partial interface IUserInfoDal:IBaseDal<UserInfo> 
    {
    } 
    public partial interface IWF_ItemDal:IBaseDal<WF_Item> 
    {
    } 
    public partial interface IWF_StepDal:IBaseDal<WF_Step> 
    {
    } 
    public partial interface IWF_TempDal:IBaseDal<WF_Temp> 
    {
    } 


}
