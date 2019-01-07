using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetAopDemo
{
    public class u : Iu
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int DAdd(int a)
        {
           return a + a;
        }
    }
}
