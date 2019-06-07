using System;
using System.Text;
using System.Text.RegularExpressions;
using CTS_BL;
using CTS_Persistence;

namespace PL_Console
{
    public class Menus
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

                if ((validate(usn) == false) || (validate(pass) == false))
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
                try
                {
                    user = ubl.Login(usn, pass);
                }
                catch (System.NullReferenceException)
                {
                    Console.Write("Mất kết nối, bạn có muốn đăng nhập lại không? (Y/N)");
                    choice = Console.ReadLine().ToUpper();
                    while (true)
                    {
                        if (choice != "Y" && choice != "N")
                        {
                            Console.Write("Bạn chỉ được nhập (C/K): ");
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
                if (user == null)
                {
                    Console.Write("Tên đăng nhập / mật khẩu không đúng, bạn có muốn đăng nhập lại không? (Y/N)");
                    choice = Console.ReadLine().ToUpper();

                    while (true)
                    {
                        if (choice != "Y" && choice != "N")
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
                break;
            }
            if (user.Type == "Waiter")
            {
                menuEmployees(user);
            }
            else if (user.Type == "Cashier")
            {
                menuPay(user);
            }
        }

        public bool validate(string str)
        {
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection matchCollectionstr = regex.Matches(str);
            // Console.WriteLine(matchCollectionstr.Count);
            if (matchCollectionstr.Count < str.Length)
            {
                return false;
            }
            return true;

        }
        public void menuEmployees(User us)
        {
            Console.Clear();
            string[] employeesmenu = { "Tạo Order món ăn", "Đăng xuất" };
            int emp = Menu("Chào mừng bạn", employeesmenu);
            switch (emp)
            {
                case 1:
                    Console.Clear();
                    // ConsoleEmployees cemp = new ConsoleEmployees();
                    try
                    {
                        // cemp.CreateSchedule(us);
                    }
                    catch (System.NullReferenceException)
                    {
                        MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI !!!");
                    }
                    catch (SystemException)
                    {
                        MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI !!!");
                    }
                    break;
                case 2:
                    Console.Clear();
                    MenuChoice(null);
                    break;
                default:
                    menuEmployees(us);
                    return;
            }
        }
        public void menuPay(User us)
        {
            Console.Clear();
            string[] Paymenu = { "Thanh Toán.", "Đăng xuất." };
            int pay = Menu("Chào mừng bạn", Paymenu);
            switch (pay)
            {
                case 1:
                    Console.Clear();
                    // ConsolePay cpay = new ConsolePay();
                    try
                    {
                        // cpay.Order(us);
                    }
                    catch (System.NullReferenceException)
                    {
                        MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI !!!");
                    }
                    catch (System.Exception)
                    {
                        MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI !!!");
                    }
                    break;
                case 2:
                    Console.Clear();
                    MenuChoice(null);
                    break;
                default:
                    menuPay(us);
                    return;
            }
        }
        public string Password()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        sb.Length--;
                    }
                    continue;
                }
                Console.Write('*');

                sb.Append(cki.KeyChar);
            }
            return sb.ToString();
        }
        public short Menu(string title, string[] menuItems)
        {
            short choose = 0;
            Console.WriteLine("=====================================================================");
            Console.WriteLine(" " + title);
            Console.WriteLine("---------------------------------------------------------------------");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine(" " + (i + 1) + ". " + menuItems[i]);
            }
            Console.WriteLine("---------------------------------------------------------------------");
            try
            {
                Console.Write("Chọn: ");
                choose = Int16.Parse(Console.ReadLine());
            }
            catch (System.Exception)
            {
            }

            if (choose == 0 || choose > menuItems.Length)
            {
                do
                {

                    try
                    {
                        Console.Write("Bạn chọn không đúng, Mời bạn chọn lại: ");
                        choose = Int16.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        continue;
                    }
                }
                while (choose <= 0 || choose > menuItems.Length);
            }

            return choose;
        }
    }
}
