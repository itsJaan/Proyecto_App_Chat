using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace BackEnd.Data.Entities
{
    public class Channel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public string theme { get; set; }

        public string  name { get; set; }

        public List<User> members { get; set; }

    }
}
