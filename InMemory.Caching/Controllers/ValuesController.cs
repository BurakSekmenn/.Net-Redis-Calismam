using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly IMemoryCache _memoryCache;

        public ValuesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        [HttpGet("set/{name}")]
        public void Set(string name)
        {
            _memoryCache.Set("name", name);// set the value in the cache
        } 
        [HttpGet]
        public string Get()
        {
            if (_memoryCache.TryGetValue("name",out string name)) // if the value is found in the cache, it will be returned
            { 
                return name.Substring(0, 1).ToUpper() + name.Substring(1); // return the value with the first letter capitalized
            } 
           
            return "No value found"; // if the value is not found in the cache, this message will be returned    
        }

        [HttpGet("setDate")]
        public void SetDate()
        {
            _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30), // the cache will expire in 30 seconds
                SlidingExpiration = TimeSpan.FromSeconds(5) // the cache will expire if it is not accessed for 5 seconds
            });
        }
        [HttpGet("getDate")]
        public DateTime GetDate()
        {
            return _memoryCache.Get<DateTime>("date");// get the value from the cache
        }


    }
}
