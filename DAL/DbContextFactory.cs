using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace DAL
{
    public class DbContextFactory
    {
        public  static DbContext GetCurrentDbContext()
        {
            //一次请求共用一个实例,返回值用DbContext ，上下文也可以改变了
            DbContext db = CallContext.GetData("DbContext") as DbContext;
            if (db == null)
            {
                //创建实例
                db = new OAEntities1();
                CallContext.SetData("DbContext", db);
            }
            return db;

        }
    }
}
