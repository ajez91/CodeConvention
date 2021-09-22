using CodeConvention.LazyLoding.Models;
using System;

namespace CodeConvention.LazyLoding
{
    class Program
    {
        //private Manager manager = new Manager();
        private Lazy<Manager> manager2 = new Lazy<Manager>();

        static void Main(string[] args)
        {
            //Manager manager = new Manager();

            //foreach (Employees e in manager.EmployeesList)
            //{
            //    Console.WriteLine(e.EmployeeName);
            //}

            Program program = new Program();

            long memory = 0;
            for (int i = 0; i < 10; i++)
            {
                memory += GC.GetTotalMemory(true);
            }
            Console.WriteLine(memory / 10);

            //var list = program.manager2.Value.EmployeesList;
            //program.manager.EmployeesList.Add(new Employees());
            program.manager2.Value.EmployeesList.Add(new Employees());

            memory = 0;
            for (int i = 0; i < 10; i++)
            {
                memory += GC.GetTotalMemory(true);
            }
            Console.WriteLine(memory / 10);

            //program.manager.EmployeesList.Add(new Employees());
            //program.manager2.Value.EmployeesList.Add(new Employees());
        }
    }
}