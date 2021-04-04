using School.Contracts;
using School.Models;
using System;
using System.Linq;

namespace School.Presentation
{/// <summary>
/// Serve para realizar a apresentação
/// </summary>
    public class ConsolePresentation
    {
        #region Propriedade
        public readonly IDataBase DataBase;
        #endregion

        public ConsolePresentation(IDataBase DataBase)
        {
            this.DataBase = DataBase;
        }

        public int ShowMenu()
        {
            Console.WriteLine("\n Select an option: ");
            Console.WriteLine("\n 0 - Insert a data ");
            Console.WriteLine("\n 1 - Show all data ");
            Console.WriteLine("\n 2 - Delete a data record ");
            Console.WriteLine("\n 3 - Update a data record ");
            Console.WriteLine("\n X - Close the program ");

            var option = Console.ReadKey(); // captura apenas uma letra (char)

            try
            {
                if (option.Key.ToString().ToLower() == "x")
                {

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


            return int.Parse(option.KeyChar.ToString());
        }

        public void Options(EnumOptions Option)
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
                    {
                        DeleteUserMenu();

                        break;
                    }
                case EnumOptions.Update:
                    {
                        UpdateUserMenu();

                        break;
                    }
                default:

                    break;
            }
        }

        private void InsertUserMenu()
        {
            User user = new User();

            Console.WriteLine("\n Insert a name: \n");
            user.Name = Console.ReadLine();


            Console.WriteLine("\n Insert a birthday Date: \n");
            user.BirthdayDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\n Insert a role name: \n");
            user.RoleList = new System.Collections.Generic.List<Role>();
            user.RoleList.Add(new Role { RoleName = Console.ReadLine() }); ///instancio o objeto e adiciono o conteudo

            this.DataBase.InsertUser(user);

        }

        private void GetAllUserMenu()
        {

            foreach (var user in this.DataBase.GetAll())
            {
                Console.WriteLine($"\n ID: {user.IdUser} \n");
                Console.WriteLine($"\n Name: {user.Name} \n");
                Console.WriteLine($"\n Birthday Date: {user.BirthdayDate} \n");
                Console.WriteLine($"\n Role name: {user.RoleList.FirstOrDefault().RoleName} \n");
            }

        }

        private void DeleteUserMenu()
        {
            var isNumber = false;
            do
            {
                Console.WriteLine("\n Digite o ID do usuário que será excluído: ");
                var input = Console.ReadLine();

                int userId;
                isNumber = int.TryParse(input, out userId);

                if (isNumber)
                {
                    if (this.DataBase.RemoveUser(userId))
                    {
                        Console.WriteLine("\n Excluído com sucesso \n");
                    }
                    else
                    {
                        Console.WriteLine("\n Id inexistente \n");
                    }

                }
                else
                {
                    Console.WriteLine("Digite apenas o número do ID");
                }

            } while (isNumber == false);

        }

        private void UpdateUserMenu()
        {
            var isNumber = false;
            do
            {
                User user = new User();

                Console.WriteLine("\n Digite o ID que deseja atualizar: \n");
                var input = Console.ReadLine();

                int userId;
                isNumber = int.TryParse(input, out userId);


                if (isNumber)
                {

                    user.IdUser = userId;

                    Console.WriteLine("\n Insert a name: \n");
                    user.Name = Console.ReadLine();


                    Console.WriteLine("\n Insert a birthday Date: \n");
                    user.BirthdayDate = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("\n Insert a role name: \n");
                    user.RoleList = new System.Collections.Generic.List<Role>();
                    user.RoleList.Add(new Role { RoleName = Console.ReadLine() }); ///instancio o objeto e adiciono o conteudo

                    if (this.DataBase.UpdateUser(user) == null)
                    {
                        Console.WriteLine("\n Não foi possível atualizar, verifique o ID informado. \n");
                    }
                    else
                    {
                        Console.WriteLine("\n Atualizado com sucesso \n");
                    }

                }
                else
                {
                    Console.WriteLine("Digite apenas números");
                }


            } while (!isNumber);



        }

    }
}
