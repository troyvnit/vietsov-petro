﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "super&savvyme<>";
            Console.WriteLine(SecurityElement.Escape(str));
            Console.ReadLine();
        }
    }
}
