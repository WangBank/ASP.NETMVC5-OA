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
       public static string AssemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];
        //public static IUserInfoDal GetUserInfoDal()
        //{
        //    //通过反射的方式,不需要new了
        //    //return new UserInfoDal();
           
        //    //return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".UserInfoDal") as IUserInfoDal;  
        //}
    }
}
