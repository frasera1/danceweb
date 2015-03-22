using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace dancenew.Data
{
    public class Schedule
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter if adult or child")]
        public string Group { get; set; }
        [Required(ErrorMessage = "Please enter a Day")]
        public string Weekday { get; set; }
        [Required(ErrorMessage = "Please enter pick correct level from list")]
        public string Level { get; set; }
        [Required(ErrorMessage = "Please enter a Class name")]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "Please enter a Start Time")]
        public string StartTime { get; set; }
        [Required(ErrorMessage = "Please enter an End Time")]
        public string EndTime { get; set; }
        [Required(ErrorMessage = "Please Choose the order you want schedule to appear.")]
        public int SortPos { get; set; }
    }
}