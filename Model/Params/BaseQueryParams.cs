using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Params
{
    public class BaseQueryParams
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int Total { get; set; }
    }
}
