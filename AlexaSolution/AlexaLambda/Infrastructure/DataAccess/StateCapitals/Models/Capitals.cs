using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaLambda.Infrastructure.DataAccess.StateCapitals.Models
{
    public class Capitals
    {
        public List<Capital> StateCapitals { get; set; }

        public Capitals()
        {
            StateCapitals = new List<Capital>();
        }
    }


}
