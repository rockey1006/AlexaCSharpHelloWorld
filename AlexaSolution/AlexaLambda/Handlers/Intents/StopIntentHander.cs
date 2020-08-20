using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Request;
using Alexa.NET.Response;
using AlexaLambda.Infrastructure.Services;

namespace AlexaLambda.Handlers.Intents
{
    public class StopIntentHander : IRequestHandler
    {
        private IGoodByeService _goodbyeSvc;
        public string IHandle => "AMAZON.StopIntent";

        public StopIntentHander(IGoodByeService goodbyeSvc)
        {
            _goodbyeSvc = goodbyeSvc;
        }

        public SkillResponse Handle(SkillRequest input)
        {
            var finalGoodBye = _goodbyeSvc.GetRandomGoodBye();
            return Alexa.NET.ResponseBuilder.Tell($" We said hello now it's time to say good bye. {finalGoodBye}");
        }
    }
}
