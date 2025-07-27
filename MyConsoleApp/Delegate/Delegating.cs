using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Delegate
{
    public class Delegating
    {
        public delegate void Notify();

        public static void MethodA()
        {
            Console.WriteLine("Method A called");
        }

        public static void MethodB()
        {
            throw new Exception();
            Console.WriteLine("Method B called");
        }
    }
}
