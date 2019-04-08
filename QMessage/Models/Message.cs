using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QMessage.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }

    }
}