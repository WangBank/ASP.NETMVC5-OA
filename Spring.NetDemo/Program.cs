using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.NetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInfoDal u = new UserInfoDal();
            u.Show();

            IApplicationContext ctx = ContextRegistry.GetContext();
            IUserInfoDal dal = ctx.GetObject("UserInfoDal") as IUserInfoDal;
            dal.Show();
            Console.ReadKey();
        }
    }
}
