using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreBlazorTutorial.Shared
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15,ErrorMessage = "Name is too long")]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Sex Sex { get; set; }
    }
    public enum Sex
    { 
        Male =1,Female,Other
    }
}
