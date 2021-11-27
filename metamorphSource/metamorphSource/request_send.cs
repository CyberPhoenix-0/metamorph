using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace metamorphSource
{
    public class request_send
    {
        
        //methode

        
        public async Task request_sender()
        {
            string headeredit = ""; //type de header a edit
            string valuedit = ""; //valeur du type a edit 
            List<string> methode = new List<string>(){"GET", "POST", "PUT"}; //GET, POST, PUT;
            int choix_methode = 0; //par defaut GET
            
            string url = "";
            
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod(methode[choix_methode]), url))
                {
                    request.Headers.TryAddWithoutValidation(headeredit, valuedit); 

                    var response = await httpClient.SendAsync(request);
                    Console.WriteLine("Request : \t" + request.Content);
                    Console.WriteLine("Response : \t" + response.Content);
                }
            }
        }
    }
}