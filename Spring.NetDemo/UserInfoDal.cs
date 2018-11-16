using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.NetDemo
{
   public  class UserInfoDal:IUserInfoDal
    {
        public string name
        {
            get;

            set;
        }

        public void Show()
        {
            Console.WriteLine("aaaaaaa" + name);
           
        }
    }
}
