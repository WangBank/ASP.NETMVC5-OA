using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public  class RedisHelper
    {
        public  RedisClient client { get; set; }
        public RedisHelper()
        {
            client = new RedisClient("192.168.5.17",6379);
        }

        public  void Add(string key,object value) {
            if (key != null && value != null)
            {
                client.Add(key,value);
            }
        }
    }
}
