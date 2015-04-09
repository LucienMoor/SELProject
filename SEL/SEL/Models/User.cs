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
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string pseudo { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth (MM/DD/YYYY)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime birthDate { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string city { get; set; }
    }
}
