using BackEnd.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace BackEnd.Api.Controllers.MeetingBotFunctions
{
    public class LuisMeetingBot
    {

        public async Task<string[]> ParseMessage(string message)
        {
            using var httpClient = new HttpClient();
            var result = await httpClient.
                GetAsync($"https://meetingbot10.cognitiveservices.azure.com/luis/prediction/v3.0/apps/97f5f9c2-bb67-4958-a0bb-f1d9522f7b00/slots/production/predict?subscription-key=339bd8a7530b4b1480d3a8c5c89c0d50&verbose=true&show-all-intents=true&log=true&query={message}");
            var stringResult = await result.Content.ReadAsStringAsync();
            var json = JObject.Parse(stringResult);

            MeetingResponseModel luisModel = JsonConvert.DeserializeObject<MeetingResponseModel>(json.ToString());
            string[] finalResult = new string[2];

            finalResult[0] = luisModel.prediction.entities.day[0][0];
            finalResult[1] = luisModel.prediction.entities.hora[0];
            return finalResult;

        }
    }
}
