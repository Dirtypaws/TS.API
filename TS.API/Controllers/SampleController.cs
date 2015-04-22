using System.Web.Http;

namespace TS.API.Controllers
{
    public class SampleController : ApiController
    {
        private static string _name = "world";
        private static object _lock = new object();

        [HttpGet]
        [Route("api/sample/Hello")]
        public string Hello()
        {
            lock (_lock)
                return string.Format("Hello {0}!", _name);
        }

        /// <summary>
        /// The FromUri allows it to look past the "Name" to find the parameter
        /// </summary>
        /// <param name="q"></param>
        [HttpGet]
        [Route("api/sample/Name")]
        public void Name(string q)
        {
            lock (_lock)
                _name = q;
        }
    }
}