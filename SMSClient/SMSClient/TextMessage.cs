using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSClient
{
    class TextMessage
    {
        public string FromNumber { get; set; }
        public string Content { get; set; }
        public string ToNumber { get; set; }
    }
}
