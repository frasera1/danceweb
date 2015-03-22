using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace dancenew.Data
{
    public class Klassen
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter Type")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Please Choose the order you want classes to appear.")]
        public int SortPos { get; set; }
    }
}