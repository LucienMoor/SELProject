using SEL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL.Models
{
    public class Message
    {
        public int ID { get; set; }
        [Required(ErrorMessage="Message is required")]
        public string message { get; set; }
        public int senderID { get; set; }
        public int destID { get; set; }
        public string title { get; set; }

        public virtual User sender { get; set; }
        public virtual User dest { get; set; }

        private SelContext context = new SelContext();

        public String getSenderPseudo(int ownerId)
        {
            User sender = context.User.Single(x => x.ID == senderID);
            return sender.pseudo;
        }
    }
}
