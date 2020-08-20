using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaLambda.Infrastructure.Config
{
    public interface IEnvironmentService
    {
        string EnvironmentName { get; set; }
    }
}
