using System;

namespace dancenew.Data
{
    public class Bio
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Biography { get; set; }
        public Byte[] Photo { get; set; }
        public string ImageUrl { get; set; }
        public int SortPos { get; set; }
    }
}