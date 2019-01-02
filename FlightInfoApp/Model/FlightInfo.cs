using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightInfoApp.Model
{
    public class FlightInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightID { get; set; }
        public string FlightNo { get; set; }
        public string FromAirport { get; set; }
        public string ToAirport { get; set; }

    }
}
