using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FirebaseTesting;

namespace webapi.Controllers
{
    public class ValuesController : ApiController
    {

        #region
        string authentication = "uKLB1Fcqv3Gog8KBraS1OqL3Tw92a2nYfDfdFqkx";
        string baseurl = "https://zurna-dbc48.firebaseio.com/";
        public static FireRepo<Country> repo;
        #endregion
        public ValuesController()
        {
            repo = new FireRepo<Country>(authentication, baseurl, $"{typeof(Country).Name.ToString()}/");
        }
        // GET api/values
        public async Task<List<Country>> GetAsync()
        {
            var resultlist = await repo.GetList();
            //repo = new FireRepo<Country>(authentication, baseurl, $"{typeof(Country).Name.ToString()}/");
            //repo.Delete(Guid.Parse("12208d50-1043-45dc-8cd6-983d12f5b272"));
            //country finded = await repo.find(guid.parse("0effe637-1001-4bdd-85a2-d8c8e5190302"));
            //console.writeline(finded.name);
            //return finded.Name.ToString();
            //return new string[] { finded.Name.ToString() };
            return resultlist;
        }

        // GET api/values/5
        [Route("api/values/{hash}")]
        public async Task<string> Get(string hash)
        {
            Country finded = await repo.Find(Guid.Parse(hash));
            return finded.Name.ToString();
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
