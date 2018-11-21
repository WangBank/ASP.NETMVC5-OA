using ServiceStack.Redis;
using System;

namespace RedisDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region 一般用法
            RedisClient client = new RedisClient("194.1.50.76", 31540);
            foreach (var term in client.GetAllKeys())
            {
                Console.WriteLine(client.GetValue(term));

            }
            Console.ReadKey();
            #endregion

            //队列，先进先出
            client.EnqueueItemOnList("s","s1");
            client.EnqueueItemOnList("s", "s2");

            //分布式栈,先进后出
            client.PushItemToList("p","p1");
            client.PushItemToList("p", "p2");

        }
    }
    }
