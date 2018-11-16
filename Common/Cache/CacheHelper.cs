using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class CacheHelper
    {
        public static ICacheWriter CacheWriter { get; set; }
        static CacheHelper()
        {
            //因为是静态的方法，如果需要依赖注入的方式进行赋值的话，首先需要注入一个ICachewriter的对象
            IApplicationContext ctx = ContextRegistry.GetContext();
            ctx.GetObject("CacheHelper");
            CacheWriter = (ICacheWriter)ctx.GetObject("CacheWriter");
        }
        public static object AddCache(string userid, object value)
        {
            return CacheWriter.Addcache(userid,value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">key</param>
        /// <param name="value">value</param>
        /// <param name="dateTime">过期时间</param>
        public static object AddCache(string userid, object value, DateTime dateTime)
        {
           return CacheWriter.Addcache(userid, value, dateTime);
        }
        /// <summary>
        /// 获取相应的value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetCache(string key)
        {
            return CacheWriter.Getcache(key);
        }

        public static void SetCache(string userid, object value)
        {
            CacheWriter.Setcache(userid, value);
        }

        public static void SetCache(string userid, object value, DateTime dateTime)
        {
            CacheWriter.Setcache(userid, value, dateTime);
        }
    }
}
