using Alexa.NET.Request;
using Alexa.NET.Request.Type;
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

            switch (input.Request.Type)
            {
                case "LaunchRequest":
                    output.Response.OutputSpeech = new PlainTextOutputSpeech("Hello! Welcome to birthday tracker! May i help you tracking birthdays? 1");
                    output.Response.ShouldEndSession = false;
                    break;
                case "SessionEndedRequest":
                    output.Response.OutputSpeech = new PlainTextOutputSpeech("Hello! Welcome to birthday tracker! May i help you tracking birthdays? 2");
                    output.Response.ShouldEndSession = false;
                    break;
                case "IntentRequest":
                    IntentRequest intentRequest = (IntentRequest)input.Request;
                    switch (intentRequest.Intent.Name)
                    {
                        case "next_birthday_intent":
                            output.Response.OutputSpeech = new PlainTextOutputSpeech("The next birthday is of John on 24nd February 2022");
                            output.Response.ShouldEndSession = false;
                            break;
                        case "AMAZON.FallbackIntent":
                            output.Response.OutputSpeech = new PlainTextOutputSpeech("Sorry. Can you repeat that?");
                            output.Response.ShouldEndSession = false;
                            break;
                    }
                    break;
            }
            return output;
        }
    }
}