using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetAopDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            Iu dal = ctx.GetObject("uuu") as Iu;
            dal.Add(1, 2);
            Console.ReadKey();
        }
    }
}
