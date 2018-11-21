using ServiceStack.Redis;
using System.Collections.Generic;
using System.Threading;

namespace Common
{
    public  class LogHelper
    {
        
        public static Queue<string> ExceptionStringqueue = new Queue<string>();
        public static List<ILogWriter> logWriterList = new List<ILogWriter>();
        /// <summary>
        /// 从队列中获取错误消息写到日志文件里面
        /// </summary>
        static LogHelper()
        {
            logWriterList.Add(new Log4NetWriter());
            ThreadPool.QueueUserWorkItem(o =>
            {
                lock (ExceptionStringqueue)
                {
                    if (ExceptionStringqueue.Count > 0)
                    {
                        string str = ExceptionStringqueue.Dequeue();
                        //把异常信息写到日志文件中，有变化点，写到不同的地方，代码尽量少的改动
                        foreach (var item in logWriterList)
                        {
                            item.WriteLog(str);
                        }
                    }
                    else {
                        Thread.Sleep(30);
                    }

                }
            });
        }
        public static void WriteLog(string text) {
            lock (ExceptionStringqueue)
            {
                ExceptionStringqueue.Enqueue(text);
            }
        }
    }
}
