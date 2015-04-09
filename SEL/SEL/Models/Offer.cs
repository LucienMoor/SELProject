using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL.Models
{
    public class Offer
    {
        public int ID { get; set; }
        public string description { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public int ownerID { get; set; }
        public string city { get; set; }

        public virtual User owner { get; set; }

        public virtual ICollection<OfferTag> tag { get; set; }
    }
}
