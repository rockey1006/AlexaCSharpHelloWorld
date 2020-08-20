using AlexaLambda.Infrastructure.DataAccess.StateCapitals.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaLambda.Infrastructure.DataAccess.StateCapitals
{
    public interface IStateCapitalsRepository
    {
        Capital GetCapital(string stateName);
    }
}
