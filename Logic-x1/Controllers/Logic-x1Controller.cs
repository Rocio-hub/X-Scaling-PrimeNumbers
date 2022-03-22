using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Logic_x1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Logic_x1Controller : ControllerBase
    {
        [HttpGet]
        [Route("GetIsPrime")]
        public bool GetIsPrime(string number)
        {
            Thread.Sleep(10000);
            return Logic1.isPrime(number);
        }

        [HttpGet]
        [Route("GetCountPrimes")]
        public string GetCountPrimes(string start, string end)
        {
            Thread.Sleep(10000);
            return Logic1.countPrimes(start, end);
        }
    }
}
