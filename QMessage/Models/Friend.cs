using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMessage.Models
{
    public class Friend
    {

        public virtual Message Message { get; set; }
        public int MessageId { get; set; }

        [NotMapped]
        public IEnumerable<Message> Units = new List<Message>();

    }
}