using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.Models
{
    public class MeetingPredictionModel
    {
        public string topIntent { get; set; }

      public MeetingEntitiesModel entities { get; set; }

    }
}
