using Memcached.Client;
using System;
using System.Text;

namespace Common.Cache
{
    public class MemcachedWriter : ICacheWriter
    {
        private  MemcachedClient mc;
        public MemcachedWriter()
        {
            //初始化memcached
            //分布Memcachedf服务IP 端口
            string[] servers = System.Configuration.ConfigurationManager.AppSettings["MemcachedAddress"].Split(','); ;
            //string[] servers = { "192.168.5.19:11211" };

            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(servers);
            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;
            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;
            pool.MaintenanceSleep = 30;
            pool.Failover = true;
            pool.Nagle = false;
            pool.Initialize();
            //客户端实例
            MemcachedClient mc1 = new MemcachedClient();
            
            mc1.EnableCompression = false;

            mc = mc1;
        }
        public object Addcache(string key, object value)
        {
            bool b = mc.Add(key,value);
            return value;
        }

        public object Addcache(string key, object value, DateTime time)
        {
          mc.Add(key, value,time);
            return value;
        }

        public void Setcache(string key, object value)
        {
            mc.Set(key,value);
        }

        public void Setcache(string key, object value, DateTime time)
        {
            mc.Set(key, value,time);
        }

        public object Getcache(string key)
        {
            return mc.Get(key);
        }
    }
}
