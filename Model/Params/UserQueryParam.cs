using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Params
{
    /// <summary>
    /// 多条件查询User类
    /// </summary>
    public class UserQueryParam:BaseQueryParams
    {
        public string SchName { get; set; }

        public string SchRemark { get; set; }


    }
}
