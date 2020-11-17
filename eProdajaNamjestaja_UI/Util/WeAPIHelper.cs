using eProdajaNamjestaja_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace eProdajaNamjestaja_UI.Util
{
    public class WeAPIHelper
    {
        private HttpClient client {get;set;}
        private string route { get; set; }

        public WeAPIHelper(string uri,string route)
        {
            client = new HttpClient();
            client.BaseAddress=new Uri(uri);
            this.route = route;
        }

        public HttpResponseMessage GetResponse()
        {
            return client.GetAsync(route).Result;
        }

        public HttpResponseMessage GetResponse(string parameter)

        {
            //api/Korisnici/denis


            return client.GetAsync(route+"/"+parameter).Result;
        }

        public HttpResponseMessage GetActionDbResponse(string action,int id)
        {
            //api/Korisnici/denis
            return client.GetAsync(route + "/"+action+"/" + id).Result;
        }

        public HttpResponseMessage GetActionResponse(string action, string parameter="")
        {
            //api/Korisnici/SearchKorisnici/denis
            return client.GetAsync(route + "/" + action + "/" + parameter).Result;
        }
        public HttpResponseMessage GetActionResponse3(string action, string vrsta , string model , string tip)
        {
            return client.GetAsync(route + "/" + action + "/" + vrsta + "/" + model + "/" + tip).Result;
        }

        public HttpResponseMessage GetActionResponse2(string action, int par1, int par2)
        {
            return client.GetAsync(route + "/" + action + "/" + par1 + "/" + par2).Result;
        }

        public HttpResponseMessage PostResponse(Object existingObject)
        {
            return client.PostAsJsonAsync(route,existingObject).Result;
        }

       

        public HttpResponseMessage PostActionResponse(string action, Object newObject)
        {
            return client.PostAsJsonAsync(route + "/" + action, newObject).Result;
        }

       

        public HttpResponseMessage PutResponse(int id,Object existingObject)
        {
            return client.PutAsJsonAsync(route+"/"+id, existingObject).Result;
        }

        
    }
}
