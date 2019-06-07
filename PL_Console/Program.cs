using System;
using System.Text;
using System.Security;
using CTS_BL;
using System.Text.RegularExpressions;
using CTS_Persistence;

namespace PL_Console
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Menus m = new Menus();
            m.MenuChoice(null);
        }
    }
}
