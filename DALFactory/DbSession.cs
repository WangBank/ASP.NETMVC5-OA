using DAL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
    /// <summary>
    /// 封装了所有Dal的实例，DAL的入口
    /// </summary>
    public partial class DbSession: IDbSession
    {
        public DbContext Db
        {
            get
            {
                return DbContextFactory.GetCurrentDbContext();
            }
        }
        //public IUserInfoDal userInfoDal
        //{
        //    get { return StaticDalFactory.GetUserInfoDal(); }
        //}

        /// <summary>
        /// 拿到当前EF的上下文，然后把修改实体作为一个整体进行提交
        /// 数据提交的权利从数据库访问曾提到了业务逻辑层
        /// 只需要一个savechanges调用的时候
        /// 大大的减少了数据库的压力
        /// 提高了性能
        /// 单元工作模式
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
