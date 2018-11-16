using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 职责：封装所有的Dal的公共的CRUD方法
    /// 类的职责单一
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDal<T> where T :class ,new ()
    {
        //基类方法DbContext
        public DbContext Db { get { return DbContextFactory.GetCurrentDbContext(); } }

        /// <summary>
        /// 查询的方法
        /// </summary>
        /// <param name="whereLambda">查询语句</param>
        /// <returns></returns>
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where(whereLambda).AsQueryable();
        }
        /// <summary>
        /// 分页的方法
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda, bool isAsc)
        {
            total = Db.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                var temp = Db.Set<T>().Where(whereLambda).OrderBy<T, S>(orderLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
                return temp;
            }
            else
            {
                var temp = Db.Set<T>().Where(whereLambda).OrderByDescending<T, S>(orderLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
                return temp;
            }
        }

        public T Add(T u)
        {
            Db.Set<T>().Add(u);
            //Db.SaveChanges();
            return u;
        }

        public T Edit(T u)
        {
            Db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            //Db.SaveChanges();
            return u;
        }

        public bool Delete(T u)
        {
            Db.Entry(u).State = System.Data.Entity.EntityState.Deleted;
            //return Db.SaveChanges() > 0;
            return true;
        }
    }
}
