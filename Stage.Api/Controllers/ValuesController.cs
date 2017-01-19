using Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Stage.Api.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IBlogsReposity _reposity;

        public ValuesController(IBlogsReposity reposity)
        {
            _reposity = reposity;
        }

        // GET api/values  
        public async Task<IEnumerable<MoBlog>> Get(int task = 6)
        {
            task = task <= 0 ? 6 : task;
            task = task > 50 ? 50 : task;
          
            return await _reposity.GetBlogs(task);
        }


        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}
