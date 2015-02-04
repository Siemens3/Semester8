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
        public int ServiceId { get; set; }
        public String Name { get; set; }
        [Index("IX_UniquePhoneNumber",1, IsUnique=true)]
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
    }
}