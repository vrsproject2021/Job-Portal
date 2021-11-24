using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class LocationModel
    {
        public int id { get; set; }

        public string street_address { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string country { get; set; }

        public string zip { get; set; }
    }
}