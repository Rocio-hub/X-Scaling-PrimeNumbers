using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Load_Balancer.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class Load_BalancerController : ControllerBase
    {
        public static int requestCount = 0;

        [HttpGet]
        [Route("GetIsPrime")]
        public Task<bool> GetIsPrime(string number)
        {
            return rr_isPrime(number);
        }

        [HttpGet]
        [Route("GetCountPrimes")]
        public Task<string> GetCountPrimes(string start, string end)
        {
            return rr_countPrimes(start, end);
        }

        public async Task<bool> rr_isPrime(string number)
        {
            requestCount++;

            if (requestCount % 2 != 0)
            {
                Console.WriteLine("This is being executed on SYSTEM1");
                RestClient c = new RestClient();
                c.BaseUrl = new Uri("https://localhost:44331/Logic_x1/GetIsPrime");
                var request = new RestRequest(Method.GET);
                request.AddParameter("number", number);
                var response = await c.ExecuteAsync<bool>(request);
                return response.Data;
            }
            else
            {
                Console.WriteLine("This is being executed on SYSTEM2");
                RestClient c = new RestClient();
                c.BaseUrl = new Uri("https://localhost:44322/Logic_x2/GetIsPrime");
                var request = new RestRequest(Method.GET);
                request.AddParameter("number", number);
                var response = await c.ExecuteAsync<bool>(request);
                return response.Data;
            }
        }

        public async Task<string> rr_countPrimes(string start, string end)
        {
            requestCount++;

            if (requestCount % 2 != 0)
            {
                Console.WriteLine("This is being executed on SYSTEM1");
                RestClient c = new RestClient();
                c.BaseUrl = new Uri("https://localhost:44331/Logic_x1/GetCountPrimes");
                var request = new RestRequest(Method.GET);
                request.AddParameter("start", start);
                request.AddParameter("end", end);
                var response = await c.ExecuteAsync<string>(request);
                return response.Data;
            }
            else
            {
                Console.WriteLine("This is being executed on SYSTEM2");
                RestClient c = new RestClient();
                c.BaseUrl = new Uri("https://localhost:44322/Logic_x2/GetCountPrimes");
                var request = new RestRequest(Method.GET);
                request.AddParameter("start", start);
                request.AddParameter("end", end);
                var response = await c.ExecuteAsync<string>(request);
                return response.Data;
            }
        }
    }
}
