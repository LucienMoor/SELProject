using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL.DAL;

namespace SEL.Models
{
    public class Tag
    {
        public int ID { get; set; }
        public string tag { get; set; }
        public virtual ICollection<OfferTag> offer { get; set; }

    }
}
