using System;

namespace CodeConvention.Solid.SinResp.Models
{
    public class ScheduleTask
    {
        public int TaskId { get; set; }
        public string Content { get; set; }
        public DateTime ExecuteOn { get; set; }
    }
}
