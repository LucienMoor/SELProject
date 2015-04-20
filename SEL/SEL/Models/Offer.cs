using SEL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL.Models
{
    public class Offer
    {
        public int ID { get; set; }
        public string description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth (MM/DD/YYYY)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime beginDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth (MM/DD/YYYY)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime endDate { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public int ownerID { get; set; }
        public string city { get; set; }
        public string name { get; set; }
        public virtual User owner { get; set; }
        public virtual ICollection<OfferTag> tag { get; set; }

        private SelContext context = new SelContext();

        public String getOwnerPseudo(int ownerId)
        {
            User owner = context.User.Single(x => x.ID == ownerId);
            return owner.pseudo;
        }
    }
}
