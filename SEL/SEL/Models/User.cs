using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage="Firstname required")]
        public string firstname { get; set; }
        [Required(ErrorMessage = "Lastname required")]
        public string lastname { get; set; }
        [Required(ErrorMessage = "Pseudo required")]
        public string pseudo { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth (MM/DD/YYYY)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> birthDate { get; set; }
        public Nullable<double> longitude { get; set; }
        public Nullable<double> latitude { get; set; }
        public string phone { get; set; }
        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage="Not a valid Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string password { get; set; }
        public string city { get; set; }
    }
}
