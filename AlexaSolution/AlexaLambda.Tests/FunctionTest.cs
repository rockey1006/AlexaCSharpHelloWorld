using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Newtonsoft.Json;

using AlexaLambda;
using Alexa.NET.Request;
using Alexa.NET.Response;

namespace AlexaLambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void InitialRequestTest()
        {

            var requestJson = "{\"version\":\"1.0\",\"session\":{\"new\":true,\"sessionId\":\"amzn1.echo - api.session.e4dec46d - b7b2 - 4514 - 84b4 - 9930a1d5e61a\",\"attributes\":null,\"application\":{\"applicationId\":\"amzn1.ask.skill.03bbda04 - fbe5 - 4889 - b374 - a572f9b660a7\"},\"user\":{\"userId\":\"amzn1.ask.account.AEYWNNJETZ5265OU2SEP2EFKOFMNP3CAU2QNBEFKT25QRFYC54CLHX36A2DDLBMOPRDWYWSDUVCDPTXBG6ITPZU2FFLRMWHAM22WJFOWBKZHVPLSM6GRPKNJGPSKEGVUUC5TS2IHY7NXJ4DXUTSJIDR6S64TKS7WTM5OX4XP3CCRXH4TA6G2VZ7DONWKZSBDDFJPKT4NUU6CWEI\",\"accessToken\":null,\"permissions\":null}},\"context\":{\"System\":{\"apiAccessToken\":\"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjAzYmJkYTA0LWZiZTUtNDg4OS1iMzc0LWE1NzJmOWI2NjBhNyIsImV4cCI6MTU5NjY1NDQ0NywiaWF0IjoxNTk2NjU0MTQ3LCJuYmYiOjE1OTY2NTQxNDcsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFBZ3RBSXhvQVRMYkhLTHhldVdncGFSS3dFQUFBQUFBQUJzL1lUeElWTm5jUmJzSzhFUzA5NDBQSERiUWFKanVZOFdHRWJHWHBpeXNuZkM0SGw2WkVSZ3FLSDRXSWd0eEdUZytoSUswaENib0J2MnN1alNkR2pqL2NhWmNUeE1uT3ZaS1lXY0ZKcVVSNGxaazA1OVdUdGxGNmZSZXppZmtGd0FTamhMVGtMcXZsU1dHU0wwR0xhdlI5T1pNbGx2SmtmaUZtOFdDdGNzdnR6UXYrWTEvTVg3WUgyV2NBbGVNMFZmcWp5bk1MTmpBckcrMU9kWUFFZmkxWTJoOFM0R1E0c0hQcUViMUVCNGpFeEMxVHQwbTVETjVYcXBYOHYzTkZtMmlnbVB5WUdINTA5QzNUUGJtbHZtWlpjRXUrT3hBZU8zS1ZteHN3MUlUbjJXN1hwbHBsOWdzSjV0NXNVVTlsRGhZNjB0cjZ4S09DbStrbWZWbGRTK2g4VXhTVFNIYmdzYkZ0bWNweUJXYmtidXFtU29VUHdDYUxDaEI0eTNnTXBQMFpZZ09mVGMxZFBWZ2c9PSIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFHWUdaNFRCRFlDTjJPUVlWWVZSQjIyWFMzVkpSSktKQkRLSlBRNUM3SzUyWDIyWkdOUkFUQVQ1TVFHR09PS0s1SlcyRVdOUjNSU0JaREZETlUyQkRFRk5HNktNR1dNWkhIWkxITFhDUEpZMlJPN1hLU1hFT1dCM0JSU043RUIzUDdYQ1pXRk9TU0lMTlZJV1kyM1ZKN0hTT0dKT08zWVY3NEtRSkxTRUFYWlEzUFJOSEIyVFkiLCJ1c2VySWQiOiJhbXpuMS5hc2suYWNjb3VudC5BRVlXTk5KRVRaNTI2NU9VMlNFUDJFRktPRk1OUDNDQVUyUU5CRUZLVDI1UVJGWUM1NENMSFgzNkEyRERMQk1PUFJEV1lXU0RVVkNEUFRYQkc2SVRQWlUyRkZMUk1XSEFNMjJXSkZPV0JLWkhWUExTTTZHUlBLTkpHUFNLRUdWVVVDNVRTMklIWTdOWEo0RFhVVFNKSURSNlM2NFRLUzdXVE01T1g0WFAzQ0NSWEg0VEE2RzJWWjdET05XS1pTQkRERkpQS1Q0TlVVNkNXRUkifX0.dZSNtTdQTfyVdiZXyC2Ou - ZgludDvH4jm6OoSdKpj1jj__3Cl54Dp632K_KYR8h5LdOdSQhnzhQL95IA_vrruzLM0Fy3TRS5NbO4IqtJ7aP - UgXe9kYKBkgYC69OwXqQCvWW7Lc0OLqcb3hsNZKrTbVFrGwGBl0f84e5SUlf5Rj1ybqmTLtzOAVJp5m7gYU7LWse3k_qLlMZUr5_BYy6wtsT7WDOK4IOW0sO2Dn7BwyzArYPrkJyfJxwBdDUcoqOSCc_dD68uZW1VxiVpru8czStWYNRVeN20tDkhGo5c4ZPT9vLrh5Awa_c0ombqJfO1SFFVQADLcays3Pw8vh99A\",\"apiEndpoint\":\"https:\\/\\/ api.amazonalexa.com\",\"application\":{\"applicationId\":\"amzn1.ask.skill.03bbda04 - fbe5 - 4889 - b374 - a572f9b660a7\"},\"user\":{\"userId\":\"amzn1.ask.account.AEYWNNJETZ5265OU2SEP2EFKOFMNP3CAU2QNBEFKT25QRFYC54CLHX36A2DDLBMOPRDWYWSDUVCDPTXBG6ITPZU2FFLRMWHAM22WJFOWBKZHVPLSM6GRPKNJGPSKEGVUUC5TS2IHY7NXJ4DXUTSJIDR6S64TKS7WTM5OX4XP3CCRXH4TA6G2VZ7DONWKZSBDDFJPKT4NUU6CWEI\",\"accessToken\":null,\"permissions\":null},\"device\":{\"deviceId\":\"amzn1.ask.device.AGYGZ4TBDYCN2OQYVYVRB22XS3VJRJKJBDKJPQ5C7K52X22ZGNRATAT5MQGGOOKK5JW2EWNR3RSBZDFDNU2BDEFNG6KMGWMZHHZLHLXCPJY2RO7XKSXEOWB3BRSN7EB3P7XCZWFOSSILNVIWY23VJ7HSOGJOO3YV74KQJLSEAXZQ3PRNHB2TY\",\"supportedInterfaces\":{}}},\"AudioPlayer\":null,\"Geolocation\":null},\"request\":{\"type\":\"LaunchRequest\",\"requestId\":\"amzn1.echo - api.request.f7512409 - 184b - 4f1c - 9d13 - e2a1b56fbbd5\",\"locale\":\"en - US\",\"timestamp\":\"2020 - 08 - 05T19: 02:27Z\"}}";

            var request = JsonConvert.DeserializeObject<SkillRequest>(requestJson);
            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            var output = function.FunctionHandler(request, context);

            Assert.False(output.Response.ShouldEndSession);
            Assert.True(((PlainTextOutputSpeech)output.Response.OutputSpeech).Text.Contains("How can I help you today?"));
        }
    }
}
