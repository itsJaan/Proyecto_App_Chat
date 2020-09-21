using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.Models
{
    public class TrelloResponseModel
    {
        public string query { get; set; }

        public TrelloPredictionModel prediction { get; set; }
    }
}
