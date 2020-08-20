using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Response;

namespace AlexaLambda.Handlers.Intents
{
    public class HelpIntentHandler : IRequestHandler
    {
        public string IHandle => "AMAZON.HelpIntent";

        public SkillResponse Handle(SkillRequest input)
        {
            var output = ResponseBuilder.Ask("Hello world likes to say hello, say Hi or hello. How can I help you today?", new Reprompt("Hello world likes to say hello, say Hi or hello., how may I help you?"));
            return output;
        }
    }
}
