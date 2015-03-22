using System.Collections.Generic;
using dancenew.Data;

namespace dancenew.ViewModels
{
    public class DDAdminViewModel
    {
        public IEnumerable<Schedule> Schedules { get; set; }
        public IEnumerable<Klassen> Classes { get; set; }
        public IEnumerable<Bio> Bios { get; set; }
        public IEnumerable<Update> Updates { get; set; }
    }
}