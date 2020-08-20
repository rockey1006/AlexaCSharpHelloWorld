using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Response;

namespace AlexaLambda.Handlers
{
    public class LaunchRequestHandler : IRequestHandler
    {
        public string IHandle => "LaunchRequest";

        public SkillResponse Handle(SkillRequest input)
        {
            var output = ResponseBuilder.Ask("How can I help you today?", new Reprompt("I don't have all day, how may I help you?"));

            output.SessionAttributes = new Dictionary<string, object>();
            output.SessionAttributes.Add("LastResponse", DateTime.Now.ToString());

            return output;
        }
    }
}
