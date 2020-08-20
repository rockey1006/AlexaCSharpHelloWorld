using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Response;
using AlexaLambda.Infrastructure.Config;

namespace AlexaLambda.Handlers.Intents
{
    public class HelloWorldIntentHandler : IRequestHandler
    {
        public string IHandle => "HelloWorldIntent";

        public SkillResponse Handle(SkillRequest input)
        {
            string timeElapse = " Time is a contruct of your imagination. ";
            if (input.Session.Attributes["LastResponse"] != null)
            {
                
                DateTime lastResponse;
                DateTime currentResponse = DateTime.Now;

                if(DateTime.TryParse(input.Session.Attributes["LastResponse"].ToString(), out lastResponse))
                {
                    TimeSpan timeSpan = currentResponse - lastResponse;
                    timeElapse = $" Your last interaction took place {timeSpan.TotalSeconds} seconds ago. ";
                }
            }
            return ResponseBuilder.Tell($" Hello World! {timeElapse} ");
        }
    }
}
