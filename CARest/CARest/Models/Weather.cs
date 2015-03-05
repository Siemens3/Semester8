using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CARest.Models
{
   
    public class Weather
    {
        public string City { get; set; }
        public bool weatherWarning { get; set; }
        [Range(-50,50)]
       public double Temp { get; set; }
        [Range(0,200)]
        public double WindSpeed { get; set; }
        public string condition { get; set; }

        
        
    }
}