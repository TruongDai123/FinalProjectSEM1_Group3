using System;
using Sustem.Text;
using System.Text.RegularExpressions;
using BL;
using Persistence;

namespace PL_Console
{
    public class Menu
    {
        public void MenuChoice(string err)
        {
            Console.Clear();
            if (err != null)
            {
                Console.WriteLine(err);
            }
            string[] choice = { "log in", "exit the program" };
            int choose = Menu("Phần mềm quản lý nhà hàng", choice);
            switch (choose)
            {
                case 1:
                    Menulogin();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
        public void Menulogin()
        {
            UserBL ubl = new UserBL();
            User user = null;
            string usn = null;
            string pass = null;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine(" LOGIN");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Uses Name");
                usn = Console.ReadLine();
                Console.WriteLine("Password");
                pass = Console.ReadLine();
                string choice;

                if ((validete(usn) == false) || (validete(pass) == false))
                {
                    Console.Write("Tên đăng nhập và mật khẩu không được chứa kí tự đặc biệt, bạn có muốn đăng nhập lại không? (Y/N)");
                    choice = Console.ReadLine().ToUpper();

                    while (true)
                    {
                        if (choice != "C" && choice != "K")
                        {
                            Console.Write("Bạn chỉ được nhập (Y/N): ");
                            choice = Console.ReadLine().ToUpper();
                            continue;
                        }
                        break;
                    }

                    switch (choice)
                    {
                        case "Y":
                            continue;
                        case "y":
                            continue;
                        case "N":
                            MenuChoice(null);
                            break;
                        case "n":
                            MenuChoice(null);
                            break;
                        default:
                            continue;
                    }
                }

            }
        }
    }
}