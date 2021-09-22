using CodeConvention.LazyLoding.Models;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace CodeConvetion.LazyLoading.Tests
{
    public class LazyLoadinngTests

    {
        private Manager manager;
        private ManagerLazyLoading lazyManager; 

        [SetUp]
        public void Init()
        {
            manager = new Manager();
            lazyManager = new ManagerLazyLoading();
        }



        [Test]
        public void EmployeeGcMemoryUsage()
        {

            // The first time, objects are put on the freachable queue and are later finalized. Afterwards, they are collectable.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var beforeGC = GC.GetTotalMemory(true);

            var employees = manager.EmployeesList; 

            var afterGC = GC.GetTotalMemory(false);

            var memoryGC = afterGC - beforeGC;

            Console.WriteLine($"Memory usage calculated with GC: {memoryGC} bytes");
            Console.WriteLine($"Memory before list initialization: {beforeGC}");
            Console.WriteLine($"Memory after list initialization: {afterGC}");
        }

        [Test]
        public void EmployeeGcMemoryUsageLazyLoading()
        {

            // The first time, objects are put on the freachable queue and are later finalized. Afterwards, they are collectable.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var beforeGC = GC.GetTotalMemory(true);

            var employees = lazyManager.EmployeesListLazy;

            var afterGC = GC.GetTotalMemory(false);

            var memoryGC = afterGC - beforeGC;

            Console.WriteLine($"Memory usage calculated with GC: {memoryGC} bytes");
            Console.WriteLine($"Memory before list initialization: {beforeGC}");
            Console.WriteLine($"Memory after list initialization: {afterGC}");

        }

        [Test]
        public void EmployeeWorkingSetProcessMemoryUsage()
        {
            var beforeProcess = Process.GetCurrentProcess().WorkingSet64;

            var employees = manager.EmployeesList;

            var afterProcess = Process.GetCurrentProcess().WorkingSet64;

            var memoryProcess = afterProcess - beforeProcess;

            Console.WriteLine($"Memory usage calculated with Working Set: {memoryProcess} bytes");
            Console.WriteLine($"Memory before list initialization: {beforeProcess}");
            Console.WriteLine($"Memory after list initialization: {afterProcess}");

        }


        [Test]
        public void EmployeeWorkingSetProcessMemoryUsageLazyLoading()
        {
            var beforeProcess = Process.GetCurrentProcess().WorkingSet64;

            var employees = lazyManager.EmployeesListLazy;

            var afterProcess = Process.GetCurrentProcess().WorkingSet64;

            var memoryProcess = afterProcess - beforeProcess;

            Console.WriteLine($"Memory usage calculated with Working Set: {memoryProcess} bytes");
            Console.WriteLine($"Memory before list initialization: {beforeProcess}");
            Console.WriteLine($"Memory after list initialization: {afterProcess}");
        }


        [Test]
        public void EmployeePrivateProcessMemoryUsage()
        {
            var beforeProcess = Process.GetCurrentProcess().PrivateMemorySize64;

            var employees = manager.EmployeesList;

            var afterProcess = Process.GetCurrentProcess().PrivateMemorySize64;

            var memoryProcess = afterProcess - beforeProcess;

            Console.WriteLine($"Memory usage calculated with Process Private: {memoryProcess} bytes");
            Console.WriteLine($"Memory before list initialization: {beforeProcess}");
            Console.WriteLine($"Memory after list initialization: {afterProcess}");
        }


        [Test]
        public void EmployeePrivateProcessMemoryUsageLazyLoading()
        {
            var beforeProcess = Process.GetCurrentProcess().PrivateMemorySize64;
            var employees = lazyManager.EmployeesListLazy;

            var afterProcess = Process.GetCurrentProcess().PrivateMemorySize64;

            var memoryProcess = afterProcess - beforeProcess;

            Console.WriteLine($"Memory usage calculated with Process Private: {memoryProcess} bytes");
            Console.WriteLine($"Memory before list initialization: {beforeProcess}");
            Console.WriteLine($"Memory after list initialization: {afterProcess}");
        }

        [Test]
        public void EmployeeVirtualProcessMemoryUsage()
        {
            var beforeProcess = Process.GetCurrentProcess().VirtualMemorySize64;

            var employees = manager.EmployeesList;

            var afterProcess = Process.GetCurrentProcess().VirtualMemorySize64;

            var memoryProcess = afterProcess - beforeProcess;

            Console.WriteLine($"Memory usage calculated with Process Virtual: {memoryProcess} bytes");
            Console.WriteLine($"Memory before list initialization: {beforeProcess}");
            Console.WriteLine($"Memory after list initialization: {afterProcess}");
        }


        [Test]
        public void EmployeeVirtualProcessMemoryUsageLazyLoading()
        {

            var beforeProcess = Process.GetCurrentProcess().VirtualMemorySize64;

            var employees = lazyManager.EmployeesListLazy;

            var afterProcess = Process.GetCurrentProcess().VirtualMemorySize64;

            var memoryProcess = afterProcess - beforeProcess;

            Console.WriteLine($"Memory usage calculated with Process Virtual: {memoryProcess} bytes");
            Console.WriteLine($"Memory before list initialization: {beforeProcess}");
            Console.WriteLine($"Memory after list initialization: {afterProcess}");
        }


        [Test]
        public void LazyLoadingExecutionComparison()
        {
            //Arrange
            var manager = new Manager();

            // The first time, objects are put on the freachable queue and are later finalized. Afterwards, they are collectable.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var beforeGC = GC.GetTotalMemory(true);

            var beforeProcess = Process.GetCurrentProcess().PrivateMemorySize64;
            var beforeProcessVirtual = Process.GetCurrentProcess().VirtualMemorySize64;
            Process.GetCurrentProcess().Dispose();


            var employees = manager.EmployeesList;

            //var employees = lazyManager.EmployeesListLazy;
            //var employees = lazyManager.EmployeesProperty;


            var afterGC = GC.GetTotalMemory(false);

            var afterProcess = Process.GetCurrentProcess().PrivateMemorySize64;
            var afterProcessVirtual = Process.GetCurrentProcess().VirtualMemorySize64;

            Process.GetCurrentProcess().Dispose();

            var beforeProcessUsing = 0.0;
            var beforeProcessUsingVirtual = 0.0;

            var afterProcessUsing = 0.0;
            var afterProcessUsingVirtual = 0.0;

            using (Process proc = Process.GetCurrentProcess())
            {
                beforeProcessUsing = proc.PrivateMemorySize64;
                beforeProcessUsingVirtual = proc.VirtualMemorySize64;
                // The proc.PrivateMemorySize64 will returns the private memory usage in byte.
                // Would like to Convert it to Megabyte? divide it by 2^20
                var employeesList = manager.EmployeesList;

                afterProcessUsing = proc.PrivateMemorySize64;
                afterProcessUsingVirtual = proc.VirtualMemorySize64;
            }

            var beforeProcessDispose = 0.0;

            Process process = Process.GetCurrentProcess();
            var afterProcessDispose = Process.GetCurrentProcess().PrivateMemorySize64;
            process.Dispose();


            /*
            //var beforeLazy = System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64;
            var beforeLazy = GC.GetTotalMemory(true);
            Console.WriteLine(beforeLazy);
            var employeesLazy = lazyManager.EmployeesListLazy;

            //var afterLazy = System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64;
            var afterLazy = GC.GetTotalMemory(false);
            Console.WriteLine(afterLazy);

            var memoryLazy = afterLazy - beforeLazy;
            //watch2.Stop();

            var beforeLazyGeneric = GC.GetTotalMemory(true);
            Console.WriteLine(beforeLazy);
            var employeesLazyGeneric = lazyManager.EmployeesProperty;

            //var afterLazy = System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64;
            var afterLazyGeneric = GC.GetTotalMemory(false);
            Console.WriteLine(afterLazy);

            var memoryLazyGeneric = afterLazyGeneric - beforeLazyGeneric;
            */


            var memoryGC = afterGC - beforeGC;
            var memoryProcess = afterProcess - beforeProcess;
            var memoryProcessVirtual = afterProcessVirtual - beforeProcessVirtual;
            var memoryProcessUsing = afterProcessUsing - beforeProcessUsing;
            var memoryProcessUsingVirtual = afterProcessUsingVirtual - beforeProcessUsingVirtual;
            var memoryProcessDispose = afterProcessDispose - beforeProcessDispose;

            Console.WriteLine($"Memory usage calculated with GC: {memoryGC} bytes");
            Console.WriteLine($"Memory usage calculated with Process: {memoryProcess} bytes");
            Console.WriteLine($"Memory usage calculated with Process Virtual: {memoryProcessVirtual} bytes");
            Console.WriteLine($"Memory usage calculated with Process Using: {memoryProcessUsing} bytes");
            Console.WriteLine($"Memory usage calculated with Process Using Virtual: {memoryProcessUsingVirtual} bytes");
            Console.WriteLine($"Memory usage calculated with Process Dispose: {memoryProcessDispose} bytes");
        }
    }
}