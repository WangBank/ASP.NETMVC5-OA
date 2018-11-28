using DALFactory;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class BaseServices<T> where T : class, new()
    {
        public BaseServices()
        {
            SetCurrent();
        }
        public abstract void SetCurrent();
        /// <summary>
        /// 父类逼迫子类给父类属性赋值
        /// 子类需要给父类属性赋值
        /// </summary>
        public IBaseDal<T> CurrentDal { get; set; }
        public IDbSession DbSession
        {
            get
            {
                return DbSessionFactory.GetCurrentDbSession();
            }
        } 
        public T Add(T t)
        {
            CurrentDal.Add(t);
            DbSession.SaveChanges();   
            return t;

        }
        /// <summary>
        /// 查询的方法
        /// </summary>
        /// <param name="whereLambda">查询语句</param>
        /// <returns></returns>
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.GetEntities(whereLambda);
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
            return CurrentDal.GetPageEntities<S>(pageSize, pageIndex, out total, whereLambda, orderLambda, isAsc);
        }

        public T Edit(T u)
        {
            CurrentDal.Edit(u);
            DbSession.SaveChanges();
            return u;
        }

        public bool Delete(T t)
        {
            CurrentDal.Delete(t);
            return DbSession.SaveChanges()>0;
        }
        
        /// <summary>
        /// 批量删除，直接删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeleteList(List<int> ids)
        {
            //真删除从数据库表中
            foreach (var id in ids)
            {
                CurrentDal.Delete(id);
            }
            return DbSession.SaveChanges();
        
        }

        public int DeleteListByLogical(List<int > ids)
        {
           CurrentDal.DeleteListByLogical(ids);
            return DbSession.SaveChanges();
        }

        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            CurrentDal.Delete(id);
            return DbSession.SaveChanges() > 0;
        }
    }
}
