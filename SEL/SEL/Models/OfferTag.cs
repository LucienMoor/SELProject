using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL.Models
{
    public class OfferTag
    {
        public int ID { get; set; }
        public int tagID { get; set; }
        public int offerID { get; set; }

        public virtual Offer offer { get; set; }
        public virtual Tag tag { get; set; }
    }
}
