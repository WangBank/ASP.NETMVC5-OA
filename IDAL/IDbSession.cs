using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public partial interface IDbSession
    {
        //IUserInfoDal userInfoDal { get; }
        int SaveChanges();
    }
}
