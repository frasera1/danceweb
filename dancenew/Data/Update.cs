using System;

namespace dancenew.Data
{
    public class Update
    {
        public int Id { get; set; }
        public string Event { get; set; }
        public DateTime ShowFrom { get; set; }
        public DateTime ShowTo { get; set; }
        public bool IsPermanent { get; set; }
        public int SortPos { get; set; }
    }
}