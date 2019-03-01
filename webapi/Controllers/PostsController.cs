using FirebaseTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace webapi.Controllers
{
    public class PostsController : ApiController
    {
        #region
        string authentication = "uKLB1Fcqv3Gog8KBraS1OqL3Tw92a2nYfDfdFqkx";
        string baseurl = "https://zurna-dbc48.firebaseio.com/";
        public static FireRepo<Post> repo;
       
        #endregion
        public PostsController()
        {
            repo = new FireRepo<Post>(authentication, baseurl, $"{typeof(Post).Name.ToString()}/");
        }
        // GET api/values
        public async Task<List<Post>> GetAsync()
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
        [Route("api/posts/{hash}")]
        public async Task<string> Get(string hash)
        {
            Post finded = await repo.Find(Guid.Parse(hash));
            return finded.id.ToString();
        }



        // POST api/values
        public async Task PostAsync([FromBody]Post post)//BURDA KALDIM(REPO2 OLUSTURDUM POST ICIN DENEDIM EKLEDI FIREA)
        {
            //Location loc = new Location {
            //    City = "Elazığ",
            //    Country = "Turkey",
            //    Lan = "123",
            //    Lat = "23"
            //};
            //Guid registerGuid = Guid.NewGuid();
            //User user = new User()
            //{
            //    id = registerGuid,
            //    DeviceId = value,
            //    Location = loc,
            //    PhoneNumber = "852654"
            //};
            await repo.Add(post, post.id);
        }

        // PUT api/values/5
        [HttpPut, Route("api/posts/{id}")]
        public async Task PutAsync(string id, [FromBody]Post post)
        {
            await repo.Update(Guid.Parse(id), post);

        }

        // DELETE api/values/5
        [HttpDelete, Route("api/posts/{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await repo.Delete(id);
        }
    }
    
}
