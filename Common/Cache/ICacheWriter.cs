using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
   public interface ICacheWriter
    {
        object Addcache(string key,object value);
        object Addcache(string key, object value,DateTime time);
        object Getcache(string key);
        void Setcache(string key, object value);
        void Setcache(string key, object value, DateTime time);
    }
}
