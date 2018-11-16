using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.NetDemo
{
    public interface IUserInfoDal
    {
        void Show();
        string name { get; set; }
    }
}
