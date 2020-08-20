using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using AlexaLambda.Handlers;
using AlexaLambda.Handlers.Intents;
using AlexaLambda.Infrastructure.Config;
using AlexaLambda.Infrastructure.DataAccess.StateCapitals;
using AlexaLambda.Infrastructure.Services;
using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
//[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AlexaLambda
{
    public class Function
    {
        public IServiceCollection _serviceCollection;
        public IServiceProvider _serviceProvider;


        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            context.Logger.Log("Input: " + JsonConvert.SerializeObject(input));

            if (_serviceCollection == null || _serviceProvider == null)
            {
                _serviceCollection = new ServiceCollection();
                ConfigureServices(_serviceCollection);
                _serviceProvider = _serviceCollection.BuildServiceProvider();
            }

            List<IRequestHandler> handlers = _serviceProvider.GetServices<IRequestHandler>().ToList();
            
            if (input.Request is LaunchRequest)
            {
                var handler = handlers.Where(h => h.IHandle == "LaunchRequest").FirstOrDefault();
                return handler.Handle(input);
            }


            if (input.Request is IntentRequest)
            {
                var intentName = (input.Request as IntentRequest).Intent.Name;
                var handler = handlers.Where(h => h.IHandle == intentName).FirstOrDefault();

                if(handler != null)
                {
                    var output = handler.Handle(input);
                    context.Logger.Log("Output: " + JsonConvert.SerializeObject(output));
                    return output;
                }
            }

            return new SkillResponse();
        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            // TODO: Register services with DI system
            serviceCollection.AddTransient<IEnvironmentService, EnvironmentService>();
            serviceCollection.AddTransient<IConfigurationService, ConfigurationService>();

            serviceCollection.AddTransient<IRequestHandler, LaunchRequestHandler>();
            serviceCollection.AddTransient<IRequestHandler, HelloWorldIntentHandler>();
            serviceCollection.AddTransient<IRequestHandler, HelpIntentHandler>();
            serviceCollection.AddTransient<IRequestHandler, StopIntentHander>();
            serviceCollection.AddTransient<IRequestHandler, StateCapitalIntentHandler>();

            serviceCollection.AddTransient<IGoodByeService, GoodByeService>();
            serviceCollection.AddSingleton<IStateCapitalsRepository, StateCapitalRepository>();
        }
    }
}
