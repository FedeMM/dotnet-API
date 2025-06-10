using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpPost]
        public decimal Add(Numbers numbers, [FromHeader] string Host, [FromHeader(Name = "Content-Length")] string ContentLength)
        {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLength);
            return numbers.a + numbers.b;
        }

    }

    public class Numbers { 
        public decimal a { get; set; }
        public decimal b { get; set; }
    }
}
