using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string message { get; set; }
        public int senderID { get; set; }
        public int destID { get; set; }
        public string title { get; set; }

        public virtual User sender { get; set; }
        public virtual User dest { get; set; }
    }
}
