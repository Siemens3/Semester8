using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CARest.Models;
namespace CARest.Controllers
{
    [RoutePrefix("weather")]
    public class WeatherController : ApiController
    {
        static List<Weather> weatherList = new List<Weather>{
            new Weather{City="Paris",Temp = 25,WindSpeed=20,condition="sunny",weatherWarning=false},
             new Weather{City="Rome",Temp = 35,WindSpeed=7,condition="sunny",weatherWarning=false},
            new Weather{City="Dublin",Temp = -2,WindSpeed=70,condition="cloudy",weatherWarning=true},
             new Weather{City="St.Petersberg",Temp = -25,WindSpeed=60,condition="snow",weatherWarning=true}
            };

        [Route("city/{city}")]
        [HttpGet]
        public IHttpActionResult OneCity(string city)
        {
            var getCity = weatherList.FirstOrDefault(c => c.City.ToUpper() == city.ToUpper());
            if (getCity == null)
            {
                return NotFound();
            }
            return Ok(getCity);
        }
        [Route("")]
        [HttpGet]
        public IHttpActionResult AllCitys()
        {
            return Ok(weatherList);
        }
        [Route("warning/{warning:bool}")]
        [HttpGet]
        public IHttpActionResult WeatherWarning(bool warning)
        {
            var getCity = weatherList.FindAll(c => c.weatherWarning == warning);
            return Ok(getCity);
        }

       
        [Route("update/{city}")]
        [HttpPut]
        public void updateCity(string city, Weather condition)
        {
            if (ModelState.IsValid)
            {
                if (city == condition.City)
                {
                    int citysearch = weatherList.FindIndex(c => c.City.ToUpper() == city.ToUpper());
                    if (citysearch == -1)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        weatherList.RemoveAt(citysearch);
                        weatherList.Add(condition);
                    }
                }

            }
        }
        [Route("add")]
        [HttpPost]
        public IHttpActionResult PostSendSMS(Weather newCity)                         // message serialised in request body
        {
            if (ModelState.IsValid)
            {
                var postcheck = weatherList.FirstOrDefault(p => p.City.ToUpper() == newCity.City.ToUpper());
                // log to file
                if (postcheck == null)
                {
                    weatherList.Add(newCity);
                    //string uri = Url.Link("weather", new { city = wadd.City });
                    //return Created(uri,wadd);
                    return Ok(newCity);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
         [Route("delete/{city}")]
        [HttpDelete]
        public IHttpActionResult DeleteEntry(String city)
        {
            var deleteCity = weatherList.Find(c=>c.City.ToUpper() == city.ToUpper());
            if (deleteCity != null)
            {
                weatherList.Remove(deleteCity);
                                  // commit
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
       
    }
}



