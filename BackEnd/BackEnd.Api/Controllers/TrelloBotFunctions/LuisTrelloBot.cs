using BackEnd.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackEnd.Api.Controllers.TrelloBotFunctions
{
    public class LuisTrelloBot
    {
        public async Task<string[]> ParseMessage(string message)
        {
            using var httpClient = new HttpClient();
            var result = await httpClient.
                GetAsync($"https://westus.api.cognitive.microsoft.com/luis/prediction/v3.0/apps/94bebfdf-b5f1-431e-b4dc-fc581131358b/slots/production/predict?subscription-key=95e4d8f49b18499da560873b76a6cc35&verbose=true&show-all-intents=true&log=true&query={message}");
            var stringResult = await result.Content.ReadAsStringAsync();
            var json = JObject.Parse(stringResult);

            TrelloResponseModel luisModel = JsonConvert.DeserializeObject<TrelloResponseModel>(json.ToString());

            
            string[] finalResult = new string[5];
            string resultFinal = luisModel.prediction.topIntent;
            int pos = luisModel.prediction.entities.idTablero.Count()-1;
            Console.WriteLine(resultFinal);
            if (resultFinal == "CrearTablero")
            {
                string[] arreglo = new string[2];
                arreglo[0] = resultFinal;
                arreglo[1] = luisModel.prediction.entities.nombreTabla[0];
                return arreglo;
            }
            else if(resultFinal== "CrearTarea" || resultFinal == "MoverTarea")
            {
                string[] arreglo = new string[4];
                arreglo[0] = resultFinal;
                arreglo[1] = luisModel.prediction.entities.nombreTarea[0];
                arreglo[2] = luisModel.prediction.entities.nombreColumna[0][0];
                arreglo[3] = luisModel.prediction.entities.idTablero[pos];
                return arreglo;
            }else if(resultFinal == "ActualizarTarea")
            {
                string[] arreglo = new string[4];
                arreglo[0] = resultFinal;
                arreglo[1] = luisModel.prediction.entities.nombreTarea[0];
                arreglo[2] = luisModel.prediction.entities.descripcion[0];
                arreglo[3] = luisModel.prediction.entities.idTablero[pos];
                return arreglo;
            }
            
            return null;

        }
    }
}
