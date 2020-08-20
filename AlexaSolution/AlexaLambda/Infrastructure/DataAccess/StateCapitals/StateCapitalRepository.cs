using Alexa.NET.Request;
using AlexaLambda.Infrastructure.DataAccess.StateCapitals.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;

namespace AlexaLambda.Infrastructure.DataAccess.StateCapitals
{
    public class StateCapitalRepository : IStateCapitalsRepository
    {
        Assembly _assembly;
        StreamReader _textStreamReader;
        Capitals _capitals;

        public StateCapitalRepository()
        {
            _assembly = Assembly.GetExecutingAssembly();
            _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("AlexaLambda.Infrastructure.DataAccess.StateCapitals.Data.USStateCapitals.json"));

            _capitals = new Capitals();
            _capitals.StateCapitals = JsonConvert.DeserializeObject<List<Capital>>(_textStreamReader.ReadToEnd());
        }
        public Capital GetCapital(string stateName)
        {
            return _capitals.StateCapitals.Where(s => s.state.ToLower() == stateName.ToLower()).FirstOrDefault();
        }
    }
}
