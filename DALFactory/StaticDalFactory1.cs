

 


using DAL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
    public partial class StaticDalFactory
    {
   
		 public static IActionInfoDal GetActionInfoDal()
        {
            //通过反射的方式,不需要new了
            //return new ActionInfoDal();
           
            return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".ActionInfoDal") as IActionInfoDal;  
        }
   
		 public static IBooksDal GetBooksDal()
        {
            //通过反射的方式,不需要new了
            //return new BooksDal();
           
            return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".BooksDal") as IBooksDal;  
        }
   
		 public static IDepartmentDal GetDepartmentDal()
        {
            //通过反射的方式,不需要new了
            //return new DepartmentDal();
           
            return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".DepartmentDal") as IDepartmentDal;  
        }
   
		 public static IFileInfoDal GetFileInfoDal()
        {
            //通过反射的方式,不需要new了
            //return new FileInfoDal();
           
            return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".FileInfoDal") as IFileInfoDal;  
        }
   
		 public static IKeyWordsRankDal GetKeyWordsRankDal()
        {
            //通过反射的方式,不需要new了
            //return new KeyWordsRankDal();
           
            return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".KeyWordsRankDal") as IKeyWordsRankDal;  
        }
   
		 public static IR_UserInfo_ActionInfoDal GetR_UserInfo_ActionInfoDal()
        {
            //通过反射的方式,不需要new了
            //return new R_UserInfo_ActionInfoDal();
           
            return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".R_UserInfo_ActionInfoDal") as IR_UserInfo_ActionInfoDal;  
        }
   
		 public static IRoleInfoDal GetRoleInfoDal()
        {
            //通过反射的方式,不需要new了
            //return new RoleInfoDal();
           
            return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".RoleInfoDal") as IRoleInfoDal;  
        }
   
		 public static ISearchDetailsDal GetSearchDetailsDal()
        {
            //通过反射的方式,不需要new了
            //return new SearchDetailsDal();
           
            return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".SearchDetailsDal") as ISearchDetailsDal;  
        }
   
		 public static IUserInfoDal GetUserInfoDal()
        {
            //通过反射的方式,不需要new了
            //return new UserInfoDal();
           
            return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".UserInfoDal") as IUserInfoDal;  
        }
   
		 public static IWF_ItemDal GetWF_ItemDal()
        {
            //通过反射的方式,不需要new了
            //return new WF_ItemDal();
           
            return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".WF_ItemDal") as IWF_ItemDal;  
        }
   
		 public static IWF_StepDal GetWF_StepDal()
        {
            //通过反射的方式,不需要new了
            //return new WF_StepDal();
           
            return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".WF_StepDal") as IWF_StepDal;  
        }
   
		 public static IWF_TempDal GetWF_TempDal()
        {
            //通过反射的方式,不需要new了
            //return new WF_TempDal();
           
            return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".WF_TempDal") as IWF_TempDal;  
        }

}
}
