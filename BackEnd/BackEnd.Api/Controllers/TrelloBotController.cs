using BackEnd.Api.Controllers.TrelloBotFunctions;
using BackEnd.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrelloBotController : ControllerBase
    {

        [HttpGet("{message}")]
        public string Get(string message)
        {
            LuisTrelloBot luisBot = new LuisTrelloBot();
            TrelloBot trelloBot = new TrelloBot();
            string resultMessage = "";

            var response = luisBot.ParseMessage(message);
            Console.WriteLine(response.Result[0]);
            if(response.Result[0] == "CrearTablero")
            {
                trelloBot.AddBoard(response.Result[1]);
                resultMessage = "Se creo el tablero " + response.Result[1];
            }
            else if (response.Result[0] == "CrearTarea")
            {
                trelloBot.AddCard(response.Result[1], response.Result[2], response.Result[3]);
                resultMessage = "Se creo el carta " + response.Result[1];
            }
            else if(response.Result[0] == "MoverTarea")
            {
                trelloBot.DeleteCard(response.Result[1], response.Result[3]);
                trelloBot.AddCard(response.Result[1], response.Result[2], response.Result[3]);
                resultMessage = "Se movio la tarea " + response.Result[1] + " a " + response.Result[2];
            }
            else if(response.Result[0] == "ActualizarTarea")
            {
                trelloBot.UpdateCard(response.Result[1], response.Result[2], response.Result[3]);
                resultMessage = "Se modifico la tarea " + response.Result[1] ;
            }
            else
            {
                resultMessage = "";
            }

            return resultMessage;
        }
       
        
        /*
         * --url 'https://api.trello.com/1/cards/
         * %7Bid%7D?key=0471642aefef5fa1fa76530ce1ba4c85&token=9eb76d9a9d02b8dd40c2f3e5df18556c831d4d1fadbe2c45f8310e6c93b5c548' \
        */

    }
}
