using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AlexaLambda.Infrastructure.Config
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}
