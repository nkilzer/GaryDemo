using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Threading;

namespace GRDemo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            return new { details = Do(id) };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
        private string Do(int id){
            if(id==1) { Thread.Sleep(5000); return @"This is the content for tab #1"; }
            if(id==2) { Thread.Sleep(8000); return @"This is the content for tab #2"; }
            if(id==3) { Thread.Sleep(2000); return @"This is the content for tab #3"; }
            return string.Format( @"This is the content for all other tabs: TAB: {0}", id );
        }
    }
}
