using School.Models;
using School.Presentation;
using School.Services;


namespace School
{
    class Program
    {
        static DataBaseService database;

        static void Main(string[] args)
        {
            database = new DataBaseService();
            ConsolePresentation presentation = new ConsolePresentation(database);//dependece injection

            do
            {
                int option = presentation.ShowMenu();
                presentation.Options((EnumOptions)option);
            } while (true);

        }

    }
}
