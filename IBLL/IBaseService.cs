using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IBaseService<T> where T :class,new()
    {
         IBaseDal<T> CurrentDal { get; set; }
         IDbSession DbSession
        {
            get;
        }
        T Add(T t);
        /// <summary>
        /// 查询的方法
        /// </summary>
        /// <param name="whereLambda">查询语句</param>
        /// <returns></returns>
         IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);
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
         IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda, bool isAsc);

       T Edit(T u);

        bool Delete(T u);

        int DeleteList(List<int> ids);

        bool Delete(int id);

        int DeleteListByLogical(List<int> ids);
    }
}
