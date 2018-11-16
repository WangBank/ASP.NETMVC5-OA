using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log4net
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Log4Helper.WriteLog("正常日志记录");
                int a =Convert.ToInt32("j");
            }
            catch(Exception ex) {
                Log4Helper.WriteLog("错误日志",ex);
            }

        }
    }
}
