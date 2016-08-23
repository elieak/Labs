using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using LINQToObjects.Extensions;

namespace LINQToObjects
{
    class Program
    {
        //Perfect
        static void Main(string[] args)
        {
            DisplayMscorlibInterfaces();
            DisplayRunningProcesses();
            GroupProcessesByPriority();
            DisplayThreadsNumbersInSystem();
            CopyToMethod();
        }

        private static void CopyToMethod()
        {
            Console.WriteLine("Press Enter to display Extension CopyTo method...");
            Console.ReadLine();

            var customer = new Customer { ID = new Random().Next(1, int.MaxValue) };
            var somePerson = new Person { Address = "Haifa", Age = new Random().Next(10, 99), Name = "Elie" };

            somePerson.CopyTo(customer);
            Console.WriteLine(customer);

            Console.WriteLine("\n\nThanks for Pressing Enters... HAPPY GRADING!!!");
        }

        private static void DisplayThreadsNumbersInSystem()
        {
            Console.WriteLine("Press Enter to display the number of Threads in the system...");
            Console.ReadLine();
            
            Console.WriteLine($"Total threads: { Process.GetProcesses().Sum(process => process.Threads.Count) }");

            Console.WriteLine("\n======================= End of Threads in system =======================");
        }

        private static void GroupProcessesByPriority()
        {
            Console.WriteLine("Press Enter to display them Ordereded By Priority...");
            Console.ReadLine();

            var processes2 = from process in Process.GetProcesses()                                 
                             //extend for b... where process.CanAccess() && process.Threads.Count < 5
                             where process.Threads.Count < 15
                             orderby process.Id
                             group new
                             {
                                 Name = process.ProcessName,
                                 ID = process.Id,
                                 Threads = process.Threads.Count
                             }
                             by process.BasePriority
                                  into grouping
                             orderby grouping.Key
                             select grouping;

            foreach (var process2 in processes2)
            {
                Console.WriteLine($"Priority: {process2.Key}");
                foreach (var process in process2)
                {
                    Console.WriteLine(process);
                }
            }
            Console.WriteLine("\n======================= End of Processes grouping =======================");
        }
        //Very Good
        private static void DisplayRunningProcesses()
        {
            Console.WriteLine("Press Enter to display the running Processes...");
            Console.ReadLine();

            var processes = from process in Process.GetProcesses()
                            where process.CanAccess() && process.Threads.Count < 5
                            orderby process.Id
                            select new
                            {
                                Name = process.ProcessName,
                                ID = process.Id,
                                Start = process.StartTime
                            };

            foreach (var process in processes)
            {
                Console.WriteLine(process);
            }

            Console.WriteLine("\n======================= End of Running Processes =======================");
        }

        private static void DisplayMscorlibInterfaces()
        {
            Console.WriteLine("Press Enter to display mscorlib Interfaces...");
            Console.ReadLine();

            var publicInterface = from pInterface in typeof(string).Assembly.GetExportedTypes() 
                                  where pInterface.IsInterface //forget && pInterface.IsPublic
                                  orderby pInterface.Name
                                  select new
                                  {
                                      TypeName = pInterface.Name,
                                      NumMethods = pInterface.GetMethods().Length
                                  };

            foreach (var intrface in publicInterface)
            {
                Console.WriteLine(intrface);
            }

            Console.WriteLine("\n======================= End of mscorlib interfaces =======================");
        }
    }


}
