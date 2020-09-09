using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.Models
{
    public class MessageModel
    {
        public long id { get; set; }

        public string message { get; set; }

        public string user { get; set; }

        public string channelName { get; set; }

        public DateTime date { get; set; }
    }
}
