using System;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using AlexaBirthdayTracker.Interfaces;
using AlexaBirthdayTracker.Models;
using AlexaBirthdayTracker.Providers;
using Microsoft.AspNetCore.Mvc;

namespace AlexaBirthdayTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlexaController : Controller
    {
        private IBirthdayDataProvider _birthdayDataProvider;

        public AlexaController(IBirthdayDataProvider bdp)
        {
            _birthdayDataProvider = bdp;
        }
        
        [HttpPost, Route("/process")]
        public SkillResponse Process(SkillRequest input)
        {
            SkillResponse output = new SkillResponse();
            output.Version = "1.0";
            output.Response = new ResponseBody();

            switch (input.Request.Type)
            {
                case "LaunchRequest":
                    output.Response.OutputSpeech = new PlainTextOutputSpeech("Hello! Welcome to birthday tracker! May i help you tracking birthdays?");
                    output.Response.ShouldEndSession = false;
                    break;
                case "SessionEndedRequest":
                    output.Response.OutputSpeech = new PlainTextOutputSpeech("Hello! Welcome to birthday tracker! May i help you tracking birthdays?");
                    output.Response.ShouldEndSession = false;
                    break;
                case "IntentRequest":
                    IntentRequest intentRequest = (IntentRequest)input.Request;
                    switch (intentRequest.Intent.Name)
                    {
                        case "next_birthday_intent":
                            Birthday birthday = _birthdayDataProvider.GetNextBirthday();
                            if (birthday != null)
                            {
                                output.Response.OutputSpeech = new PlainTextOutputSpeech(String.Format("The next birthday is of {0} on {1}", birthday.Name, birthday.Date.ToString("D")));   
                            }
                            else
                            {
                                output.Response.OutputSpeech = new PlainTextOutputSpeech("Sorry! No Birthdays found!");
                            }
                            output.Response.ShouldEndSession = false;
                            break;
                        case "named_birthday_intent":
                            
                            string name = intentRequest.Intent.Slots["name"].SlotValue.Value;
                            
                            Birthday named = _birthdayDataProvider.GetBirthday(name);
                            
                            if (named != null)
                            {
                                output.Response.OutputSpeech = new PlainTextOutputSpeech(String.Format("The Birthday of {0} is on: {1}", named.Name, named.Date.ToString("D")));   
                            }
                            else
                            {
                                output.Response.OutputSpeech = new PlainTextOutputSpeech("Sorry! No Birthdays found!");
                            }
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