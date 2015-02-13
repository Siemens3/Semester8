using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class SMSGateway
    {
        [Required]
        [Phone]
        public string FromNumber { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(140)]
        public string Content { get; set; }

        [Required]
        [Phone]
        public string ToNumber { get; set; }
    }
}