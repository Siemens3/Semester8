﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace phonebookClient
{
    class Program
    {
        static async Task DoWork()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:27028/");                             // base URL for API Controller i.e. RESTFul service

                    // Accept JSON
                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    // GET ../phonebook/name/John Doe
                    HttpResponseMessage response = await client.GetAsync("phonebook/name/Brian Mahon");
                    if (response.IsSuccessStatusCode)
                    {
                        // read result 
                        var entries = await response.Content.ReadAsAsync<IEnumerable<phonebook>>();
                        foreach (var entry in entries)
                        {
                            Console.WriteLine(entry.Address + " " + entry.Number);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }


                    // GET ../phonebook/number/01 3333333
                    response = await client.GetAsync("phonebook/number/0853658422");
                    if (response.IsSuccessStatusCode)
                    {
                        // read result 
                        var result = await response.Content.ReadAsAsync<phonebook>();
                        Console.WriteLine(result.Name + " " + result.Address);
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void Main(string[] args)
        {
            DoWork().Wait();
            Console.ReadLine();
        }
       
    }
}
