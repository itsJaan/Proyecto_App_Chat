using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackEnd.Data.Entities
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public string message { get; set; }

        public string user { get; set; }

        public string channelName { get; set; }

        public DateTime date { get; set; }


    }
}
