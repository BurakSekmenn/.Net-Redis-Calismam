using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace Distributed.Caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
       readonly IDistributedCache _distributedCache;

        public ValuesController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        // setstring kullaılarak string tipinde veri cache'e eklenir. // getstring ile alırken string tipinde alırız.
        // set kullaılarak byte[] tipinde veri cache'e eklenir. bunu daha sonra get ile alırken byte[] tipinde alırız.

        [HttpGet("set")]
        public async Task<IActionResult> Set(string name,string surname)
        {
            await _distributedCache.SetStringAsync("isim", name,options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });
            await _distributedCache.SetAsync("soyisim", Encoding.UTF8.GetBytes(surname), options: new()
             {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });
            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
           var name= await _distributedCache.GetStringAsync("isim");// string tipinde veri döner
           var surnameBinary = await _distributedCache.GetAsync("soyisim"); // byte[] tipinde veri döner
           var surname =  Encoding.UTF8.GetString(surnameBinary);// byte[] tipinde veriyi stringe çevirir.
            return Ok(new
            {
                name,
                surname
            });
        }

    }
}
