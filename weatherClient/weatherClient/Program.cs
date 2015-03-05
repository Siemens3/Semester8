using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

//////////////--------------------------------------------------Mine-------------------------------------------//////////////////////////
namespace WeatherClient
{
    class Program
    {
        static async Task Run()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:21265/");                             // base URL for API Controller i.e. RESTFul service

                    // add an Accept header for JSON
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // 1
                    // get weather info for all cities
                    // GET ../api/weather
                    HttpResponseMessage response = await client.GetAsync("weather/");               // accessing the Result property blocks
                    if (response.IsSuccessStatusCode)                                                  // 200.299
                    {
                        // read result 
                        var weather = await response.Content.ReadAsAsync<IEnumerable<Weather>>();
                        foreach (var w in weather)
                        {
                            Console.WriteLine(w.City + " " + w.Temp + "C " + w.WindSpeed + "km/h " + w.Condition + " warning: " + w.WeatherWarning);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                    
                    // 2
                    // get weather info for Dublin
                    // GET ../api/weather/Dublin
                    Weather weatherInfo = new Weather();
                    response = await client.GetAsync("weather/city/Dublin");
                    if (response.IsSuccessStatusCode)
                    {
                        // read result 
                        weatherInfo = await response.Content.ReadAsAsync<Weather>();
                        Console.WriteLine(weatherInfo.City + " " + weatherInfo.Temp + "C " + weatherInfo.WindSpeed + "km/h " + weatherInfo.Condition + " Warning: " + weatherInfo.WeatherWarning);
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }


                  
                    
                    // 3
                    // update by Put to api/weather/Dublin - now its sunny
                  //  weatherInfo.Condition = Conditions.sunny;
                   weatherInfo.Condition  = "Sunny";
                   response = await client.PutAsJsonAsync("weather/update/Dublin", weatherInfo);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response.Content+" "+"city updated");
                       
                    }
                    else{
                        Console.WriteLine("update failed");
                         Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                    
                    // 4
                    // get cities with weather warnings in place
                    // GET ../api/weather?warning=true
                    response = await client.GetAsync("weather/warning/true");
                    if (response.IsSuccessStatusCode)
                    {
                        // read result 
                        var cities = await response.Content.ReadAsAsync<IEnumerable<Weather>>();
                        foreach (var city in cities)
                        {
                            Console.WriteLine(city.City+" "+city.Condition);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                    response = await client.DeleteAsync("weather/delete/Dublin");
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("City deleted ");
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    // POST /api/SMSGateway with a txt message serialised in request body
                    // send a txt msg
                    Weather newCity = new Weather() { City = "London", WindSpeed = 8, Temp = 8, Condition = "cold", WeatherWarning = true};
                    response = await client.PostAsJsonAsync("weather/add", newCity);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Added City " + newCity.City + " with " + newCity.Condition + " conditions");
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                    
                    // Delete/weather/delete/01 4444444
                   
                     
                }
                    
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public static void Main()
        {
            Run().Wait();
            Console.ReadLine();
        }
    }
}
