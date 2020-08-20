using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaLambda.Infrastructure.Services
{
    public class GoodByeService : IGoodByeService
    {
        public string GetRandomGoodBye()
        {
            string[] goodByes = new string[] {" Hasta la vista baby! ", " TTFN ", " Catch ya later. ", " Frickety frack I hope you come back. " };

            var random = new Random();
            var i = random.Next(0, goodByes.Length - 1);

            return goodByes[i];
        }
    }
}
