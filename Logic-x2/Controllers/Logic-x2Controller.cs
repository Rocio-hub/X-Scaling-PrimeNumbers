using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Logic_x2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Logic_x2Controller : ControllerBase
    {
        [HttpGet]
        [Route("GetIsPrime")]
        public bool GetIsPrime(string number)
        {
            Thread.Sleep(10000);
            return Logic2.isPrime(number);
        }

        [HttpGet]
        [Route("GetCountPrimes")]
        public string GetCountPrimes(string start, string end)
        {
            Thread.Sleep(10000);
            return Logic2.countPrimes(start, end);
        }
    }
}
