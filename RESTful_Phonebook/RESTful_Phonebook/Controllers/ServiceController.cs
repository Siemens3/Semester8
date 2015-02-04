using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTful_Phonebook.Models;

namespace RESTful_Phonebook.Controllers
{
    public class ServiceController : ApiController
    {
        List<Service> Services = new List<Service> {
        new Service{ ServiceId = 1, Name = "John doe", PhoneNumber = "0853658422", Address ="10 Brookview grove,Tallaght,Dublin 24" },
        new Service{ ServiceId = 2, Name = "Rick shaw", PhoneNumber = "0897816944", Address ="14 Rossfield way,Tallaght,Dublin 24 " },
        new Service{ ServiceId = 3, Name = "Brian Mahon", PhoneNumber = "0852350865", Address ="89 Saint fibarrs close,greenhills, Dublin 12 " },
        new Service{ ServiceId = 4, Name = "Shane Gough", PhoneNumber = "0869124588", Address = "113 orchard lodge green,curragh, co.Kildare"},
    };
        // GET: api/Service
        public IEnumerable<Service> Get()
        {
            return Services;
        }

        // GET: api/Service/5
        public Service Get(string name)
        {
            return Services.SingleOrDefault(s =>s.Name == name) ;
        }

        // POST: api/Service
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Service/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Service/5
        public void Delete(int id)
        {
        }
    }
}
