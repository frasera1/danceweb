using System.Collections.Generic;
using dancenew.Data;

namespace dancenew.ViewModels
{
    public class ScheduleVM
    {
        public IEnumerable<Schedule> AdultsAdvanced { get; set; }
        public IEnumerable<Schedule> AdultsBeginner { get; set; }
        public IEnumerable<Schedule> Kids34 { get; set; }
        public IEnumerable<Schedule> Kids34Eng { get; set; }
        public IEnumerable<Schedule> Kids57 { get; set; }
        public IEnumerable<Schedule> AdultModern { get; set; }
    }
}