using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using AlexaLambda.Infrastructure.DataAccess.StateCapitals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlexaLambda.Handlers.Intents
{
    public class StateCapitalIntentHandler : IRequestHandler
    {
        private IStateCapitalsRepository _stateCapitalRepo;
        public string IHandle => "UnitedStatesCapitals";

        public StateCapitalIntentHandler(IStateCapitalsRepository stateCapitalRepo)
        {
            _stateCapitalRepo = stateCapitalRepo;
        }

        public SkillResponse Handle(SkillRequest input)
        {
            IntentRequest request = input.Request as IntentRequest;
            string stateName = request.Intent.Slots["statecapitals"].Value;

            if(request.Intent.Slots["statecapitals"].Resolution.Authorities.Any())
            {
                stateName = request.Intent.Slots["statecapitals"].Resolution.Authorities[0].Values[0].Value.Name;
            }

            var capital = _stateCapitalRepo.GetCapital(stateName);

            if(capital == null)
            {
                return ResponseBuilder.Ask(" I do not know the capital you are asking about, how may I help you? "
                    , new Reprompt("I do not have all day, how may I help you?"));
            }

            var output = ResponseBuilder.Ask($" The capital city of {stateName} is {capital.capital}. Got any more brain busters I can answer? "
                , new Reprompt("I do not have all day, how may I help you?"));
            return output;
        }
    }
}
