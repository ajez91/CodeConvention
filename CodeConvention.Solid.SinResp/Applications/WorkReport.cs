using CodeConvention.Solid.SinResp.Interfaces;
using CodeConvention.Solid.SinResp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeConvention.Solid.SinResp.Applications
{
    // 3) The only change to the WorkReport class is to implement IEntryManager
    public class WorkReport : IEntryManager<WorkReportEntry>
    {
        private readonly List<WorkReportEntry> _entries;

        public WorkReport()
        {
            _entries = new List<WorkReportEntry>();
        }

        public void AddEntry(WorkReportEntry entry) => _entries.Add(entry);

        public void RemoveEntryAt(int index) => _entries.RemoveAt(index);

        // 1) Because we have our WorkReport class, 
        //it is quite fine to add our additional features to it, like saving to a file

        //2) The first thing we need to do is to separate the part of our code that is unlike others. 
        //In our case, that  is obviously the SaveToFile method, so we are going to move it to 
        //another class which is more appropriate (FileServer.cs)

        //public void SaveToFile(string directoryPath, string fileName)
        //{
        //    if (!Directory.Exists(directoryPath))
        //    {
        //        Directory.CreateDirectory(directoryPath);
        //    }
        //    File.WriteAllText(Path.Combine(directoryPath, fileName), ToString());
        //}

        public override string ToString() =>
            string.Join(Environment.NewLine, _entries.Select(x => $"Code: {x.ProjectCode}, Name: {x.ProjectName}, Hours: {x.SpentHours}"));
    }
}
