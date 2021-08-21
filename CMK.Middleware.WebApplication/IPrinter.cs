using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMK.Middleware.WebApplication
{
    public interface IPrinter
    {
        void Print();
    }

    public class Printer : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Printing ...");
        }
    }
}
