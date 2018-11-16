using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
    public class DbSessionFactory
    {
        public static IDbSession GetCurrentDbSession()
        {
            IDbSession dbsession = CallContext.GetData("DbSession") as IDbSession;
            if(dbsession == null)
            {
                dbsession = new DbSession();
                CallContext.SetData("DbSession", dbsession);
            }
            return dbsession;
        }
    }
}
