using System.Web.Mvc;
using AspNet46ConfigurationDemo.Configuration;

namespace AspNet46ConfigurationDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public ActionResult Index()
        {
            // Reading a value from the config.
            // In a real world application you would usually read values such as
            // connection strings, but in this simple example I just read a text
            // which I output to the user to proof the basic concept works.
            var greetingText = _config.Get("GreetingText");

            return Content(greetingText);
        }
    }
}