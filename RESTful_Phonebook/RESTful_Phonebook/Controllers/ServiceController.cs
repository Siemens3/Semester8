using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RESTful_Phonebook.Models;
using System;

namespace RESTful_Phonebook.Controllers
{
    [RoutePrefix("phonebook")]
    public class ServiceController : ApiController
    {
        List<Service> Services = new List<Service> {
        new Service{  Number = "0853658422",Name = "John doe",  Address ="10 Brookview grove,Tallaght,Dublin 24" },
        new Service{   Number = "0897816944",Name = "Rickshaw", Address ="14 Rossfield way,Tallaght,Dublin 24 " },
        new Service{  Number = "0852350865",Name = "Brian Mahon",  Address ="89 Saint fibarrs close,greenhills, Dublin 12 " },
        new Service{  Number = "0869124588", Name = "Shane Gough", Address = "113 orchard lodge green,curragh, co.Kildare"},
    };
        //get: phonebook/Service
        // GET: api/Service
      /*  public IHttpActionResult GetAll()
        {
            return Ok(Services);
        }*/

        // GET: /Service/id
          [Route("number/{number}")]
        public IHttpActionResult GetByNumber(String number)
        {

            var entry = Services.FirstOrDefault(s => s.Number.ToUpper() == number.ToUpper());
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        // GET: api/Service/name
        [Route("name/{name}")]
        public IHttpActionResult GetByName(String name)
        {
            var entry= Services.Where(s => s.Name.ToUpper() == name.ToUpper());
          
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        /*
        // POST: api/Service
        public void Post([FromBody]Service Service)
        {
            Services.Add(Service); 
            //save changes
        }
       // http://www.mikesdotnetting.com/article/261/integrating-web-api-with-asp-net-razor-web-pages
        // PUT: api/Service/5
        public void Put(string name, [FromBody]Service service)
        {
            Service existingService = Services.SingleOrDefault(s => s.Name == name);
            existingService.Name = service.Name;
            existingService.PhoneNumber = service.PhoneNumber;
            existingService.Address = service.Address;


        }

        // DELETE: api/Service/5
        public void Delete(string name)
        {
            Services.Remove(Services.SingleOrDefault(s => s.Name == name));
        }
         * */
    }
}
