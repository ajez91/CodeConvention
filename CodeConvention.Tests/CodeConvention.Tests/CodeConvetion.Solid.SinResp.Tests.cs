using System;
using System.IO;
using CodeConvention.Solid.SinResp.Applications;
using CodeConvention.Solid.SinResp.Models;
using NUnit.Framework;

namespace CodeConvetion.Solid.sinResp.Tests
{
    public class SingleResponsibilityTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WorkReportEntries()
        {
            //Arrange
            var report = new WorkReport();
            report.AddEntry(new WorkReportEntry { ProjectCode = "123Ds", ProjectName = "Project1", SpentHours = 5 });
            report.AddEntry(new WorkReportEntry { ProjectCode = "987Fc", ProjectName = "Project2", SpentHours = 3 });
            
            //Act
            Console.WriteLine(report.ToString());
            var saver = new FileSaver();
            saver.SaveToFile(@"Reports", "WorkReport.txt", report);

            //Assert
            Assert.True(File.Exists(@"Reports/WorkReport.txt"));
        }

        [Test]
        public void WorkReportScheduler()
        {
            //Arrange
            var report = new WorkReport();
            report.AddEntry(new WorkReportEntry { ProjectCode = "123Ds", ProjectName = "Project1", SpentHours = 5 });
            report.AddEntry(new WorkReportEntry { ProjectCode = "987Fc", ProjectName = "Project2", SpentHours = 3 });
            
            var scheduler = new Scheduler();
            scheduler.AddEntry(new ScheduleTask { TaskId = 1, Content = "Do something now.", ExecuteOn = DateTime.Now.AddDays(5) });
            scheduler.AddEntry(new ScheduleTask { TaskId = 2, Content = "Don't forget to...", ExecuteOn = DateTime.Now.AddDays(2) });
            
            //Act
            Console.WriteLine(report.ToString());
            Console.WriteLine(scheduler.ToString());
            
            var saver = new FileSaver();
            saver.SaveToFile(@"Reports", "WorkReport.txt", report);
            saver.SaveToFile(@"Schedulers", "Schedule.txt", scheduler);

            //Assert
            Assert.True(File.Exists(@"Reports/WorkReport.txt"));
            Assert.True(File.Exists(@"Schedulers/Schedule.txt"));

        }
    }
}