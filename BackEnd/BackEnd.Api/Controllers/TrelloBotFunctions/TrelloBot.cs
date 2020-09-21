using BackEnd.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackEnd.Api.Controllers.TrelloBotFunctions
{
    public class TrelloBot
    {
        private string url = "https://api.trello.com/1/";
        private string token = "77fdf7d4cbb4f2e93ed539c0845ed25e144a52f25fbe8e115d282ed9c7402f0f";
        private string key = "77a3903029c03bc2ff1f16151d9e32bc";

        public void AddBoard(string name)
        {
            url = url + "boards/?key=" + key + "&token=" + token + "&name=" + name;

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, null).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public string SearchCard(string name, string idList)
        {
            url = "https://api.trello.com/1/";
            url = url + "lists/" + idList + "/cards?key=" + key + "&token=" + token;

            WebRequest test = WebRequest.Create(url);
            Stream objStream;
            objStream = test.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);
            string json = "";
            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                    json = json + sLine;

            }

            var cardModel = JsonConvert.DeserializeObject<List<CardModel>>(json);

            foreach (CardModel x in cardModel)
            {
                if (x.name == name)
                {
                    return x.id;
                }
            }
            return "";
        }

        public void AddCard(string name, string listName, string idBoard)
        {
            url = "https://api.trello.com/1/";
            url = url + "boards/" + idBoard + "/lists?key=" + key + "&token=" + token;

            WebRequest test = WebRequest.Create(url);
            Stream objStream;
            objStream = test.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);
            string json = "";
            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                    json = json + sLine;

            }

            var listModel = JsonConvert.DeserializeObject<List<ListModel>>(json);
            string idList = "";
           
            foreach (ListModel x in listModel)
            {
                if (x.name == listName)
                {
                    idList = x.id;
                    break;
                }
            }
            Console.WriteLine(idList);
            url = "https://api.trello.com/1/";
            url = url + "cards?key=" + key + "&token=" + token + "&idList=" + idList +"&name=" + name  ;

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, null).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void DeleteCard(string name, string idBoard)
        {
            url = "https://api.trello.com/1/";
            url = url + "boards/" + idBoard + "/lists?key=" + key + "&token=" + token;

            WebRequest test = WebRequest.Create(url);
            Stream objStream;
            objStream = test.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);
            string json = "";
            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                    json = json + sLine;

            }

            var listModel = JsonConvert.DeserializeObject<List<ListModel>>(json);

            foreach (ListModel x in listModel)
            {
                string idCard = SearchCard(name, x.id);

                if (idCard != "")
                {
                    url = "https://api.trello.com/1/";
                    url = url + "cards/" + idCard + "?key=" + key + "&token=" + token;
                    using (var client = new HttpClient())
                    {
                        var response = client.DeleteAsync(url).Result;
                        response.EnsureSuccessStatusCode();
                    }
                    break;
                }

            }
        }

        public void UpdateCard(string nameCard,string desc, string idBoard )
        {
            url = "https://api.trello.com/1/";
            url = url + "boards/" + idBoard + "/lists?key=" + key + "&token=" + token;

            WebRequest test = WebRequest.Create(url);
            Stream objStream;
            objStream = test.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);
            string json = "";
            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                    json = json + sLine;

            }

            string idCard = "";
            var listModel = JsonConvert.DeserializeObject<List<ListModel>>(json);
            foreach (ListModel x in listModel)
            {
               idCard = SearchCard(nameCard, x.id);
                if(idCard != "")
                {
                    url = "https://api.trello.com/1/";
                    url = url + "cards/" + idCard + "?key=" + key + "&token=" + token + "&desc=" + desc;
                    using (var client = new HttpClient())
                    {
                        var response = client.PutAsync(url, null).Result;
                        response.EnsureSuccessStatusCode();
                    }
                    break;
                }
            }

            
        }
    }
}
