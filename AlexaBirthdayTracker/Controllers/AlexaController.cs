using Alexa.NET.Request;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Mvc;

namespace AlexaBirthdayTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlexaController : Controller
    {
        [HttpPost, Route("/process")]
        public SkillResponse Process(SkillRequest input)
        {
            SkillResponse output = new SkillResponse();
            output.Version = "1.0";
            output.Response = new ResponseBody();
            output.Response.OutputSpeech = new PlainTextOutputSpeech("Hello this works");
            return output;
        }
    }
}