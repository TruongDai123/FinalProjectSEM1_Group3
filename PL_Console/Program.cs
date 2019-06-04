using System;
using System.Text;
using System.Security;
using BL;
using System.Text.RegularExpressions;
using Persistence;

namespace PL_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Menus m = new Menus();
            m.MenuChoice(null);
        }
    }
}
