using CodeConvention.Solid.SinResp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeConvention.Solid.SinResp.Models
{
    public class FileSaver
    {
        //4) we have to change the SaveToFile method signature
        //public void SaveToFile(string directoryPath, string fileName, WorkReport report)

        public void SaveToFile<T>(string directoryPath, string fileName, IEntryManager<T> workReport)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            File.WriteAllText(Path.Combine(directoryPath, fileName), workReport.ToString());
        }
    }
}

