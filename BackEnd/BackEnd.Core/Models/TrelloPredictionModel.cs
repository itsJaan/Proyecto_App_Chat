using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.Models
{
    public class TrelloPredictionModel
    {
        public string topIntent { get; set; }

        public TrelloEntitiesModel entities { get; set; }
    }
}
