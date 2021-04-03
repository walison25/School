using School.Models;
using School.Services;
using System;
using System.Linq;


namespace School
{
    class Program
    {
        static DataBaseService database;
        static void Main(string[] args)
        {
            database = new DataBaseService();

            do
            {
                int option = ShowMenu();
                Options((EnumOptions)option);
            } while (true);

            Console.ReadKey();
        }

        private static int ShowMenu()
        {
            Console.WriteLine("\n Select an option: ");
            Console.WriteLine("0 - Insert a data");
            Console.WriteLine("1 - Show all data ");
            Console.WriteLine("2 - Delete a data record");
            Console.WriteLine("3 - Update a data record");
            Console.WriteLine("X - Close the program \n");

            var option = Console.ReadLine();

            try
            {
                if (option.ToLower() == "x") {

                    Console.WriteLine("\n Thank's! I'm closing the program... \n");
                    Environment.Exit(0);
                }

            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("\n Please enter only the number corresponding to the option: \n");
                ShowMenu();
            }


            return int.Parse(option);
        }


        private static void Options(EnumOptions Option)
        {
            switch (Option)
            {
                case EnumOptions.Insert:
                    {
                        InsertUserMenu();
                      
                        break;
                    }

                case EnumOptions.GetAll:
                    {
                        GetAllUserMenu();
                 
                        break; 
                    }
                case EnumOptions.Delete:
                    break;
                case EnumOptions.Update:
                    break;
                default:

                    break;
            }
        }


        private static void InsertUserMenu()
        {
            User user = new User();

            Console.WriteLine("\n Insert a name: \n");
            user.Name = Console.ReadLine();


            Console.WriteLine("Insert a birthday Date: \n");
            user.BirthdayDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Insert a role name: \n");
            user.RoleList = new System.Collections.Generic.List<Role>();
            user.RoleList.Add(new Role { RoleName = Console.ReadLine() }); ///instancio o objeto e adiciono o conteudo

            database.InsertUser(user);
          
        }


        private static void GetAllUserMenu()
        {
          
            foreach (var user in database.GetAll())
            {
                Console.WriteLine($"ID: {user.IdUser}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Birthday Date: {user.BirthdayDate}");
                Console.WriteLine($"Role name: {user.RoleList.FirstOrDefault().RoleName}");
            }

        }



    }
}
