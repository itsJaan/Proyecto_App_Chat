using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.Models
{
    public class MeetingResponseModel
    {
        public string query { get; set; }

        public MeetingPredictionModel prediction { get; set; }

    }
}
