using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackEnd.Data.Entities
{
    public class User
    {
        [Key]
        public string username { get; set; }

        public string password { get; set; }
        
        public string  name { get; set; }

    }
}
