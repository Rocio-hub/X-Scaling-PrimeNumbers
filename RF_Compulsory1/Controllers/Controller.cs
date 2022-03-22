
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RF_Compulsory1.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class Controller : ControllerBase
    {
        [HttpGet]
        [Route("GetIsPrime")]
        public async Task<bool> GetIsPrime(string number)
        {
            string startTime = DateTime.Now.ToString("HH:mm:ss tt");
            RestClient c = new RestClient();
            c.BaseUrl = new Uri("https://localhost:44304/Load_Balancer/GetIsPrime");
            var request = new RestRequest(Method.GET);
            request.AddParameter("number", number);
            var response = await c.ExecuteAsync<bool>(request);

            Console.WriteLine("Inserted number: " + number + "\tReturned value: " + response.Data 
                + "\tStarted at: " + startTime + "\tEnded at: " + DateTime.Now.ToString("HH:mm:ss tt"));
    
            return response.Data;
        }

        [HttpGet]
        [Route("GetCountPrimes")]
        public async Task<string> GetCountPrimes(string start, string end)
        {
            string startTime = DateTime.Now.ToString("HH:mm:ss tt");
            RestClient c = new RestClient();
            c.BaseUrl = new Uri("https://localhost:44304/Load_Balancer/GetCountPrimes");
            var request = new RestRequest(Method.GET);
            request.AddParameter("start", start);
            request.AddParameter("end", end);
            var response = await c.ExecuteAsync<string>(request);

            Console.WriteLine("Count primes from " + start + " \tto " + end +"\tResult: " + response.Data + "\tStarted at: " + startTime + "\tEnded at: " + DateTime.Now.ToString("HH:mm:ss tt"));
            return response.Data;
        }
    }
}
