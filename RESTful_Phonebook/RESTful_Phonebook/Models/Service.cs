using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RESTful_Phonebook.Models
{
    public class Service
    {
        public string Number { get; set; }              // unique
        public string Name { get; set; }
        public string Address { get; set; }
    }
}