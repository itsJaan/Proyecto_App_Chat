using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.Models
{
    public class TrelloEntitiesModel
    {
        public List<string> nombreTabla { get; set; }

        public List<string[]> nombreColumna { get; set; }

        public List<string> nombreTarea { get; set; }

        public List<string> idTablero { get; set; }

        public List<string> descripcion { get; set; }
    }
}
