using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Request;
using Alexa.NET.Response;

namespace AlexaLambda.Handlers
{
    public interface IRequestHandler
    {
        string IHandle { get; }
        SkillResponse Handle(SkillRequest input);
    }
}
