using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class StateModel
    {
        public int RowId { get; set; }

        public int? CountryId { get; set; }

        public string StateName { get; set; }
    }
}
