using AopAlliance.Intercept;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetAopDemo
{
    public class ConsoleLoggingAroundAdvice:IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            Console.Out.WriteLine("方法执行前"); 
            object returnValue = invocation.Proceed(); 
            Console.Out.WriteLine("方法执行后" + returnValue); 
            return returnValue; 
        }
    }
}
