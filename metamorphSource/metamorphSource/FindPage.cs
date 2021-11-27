using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace ConsoleApplication3
{
    public class FindPage
    {
        public static string _url;

        public FindPage(string url)
        {
            FindPage._url = url;
        }
        public async Task Find()
        {
            FileStream log = File.Create("log.txt");
            StreamReader streamReader = new StreamReader("common.txt");
            string ligne;
            List<string> found = new List<string>();

            while ((ligne = await streamReader.ReadLineAsync()) != null)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), _url + ligne ))
                    {
                        var response = await httpClient.SendAsync(request);
                        Console.WriteLine(_url + ligne + "\t Status: " + response.StatusCode);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            found.Add(_url + ligne + "\t Status: " + response.StatusCode);
                        }
                    }
                }
            }
            log.Close();
            foreach (var var in found)
            {
                Console.WriteLine(var);
            }

            foreach (var founder in found)
            {
                Console.WriteLine(founder);
            }
            
            streamReader.Close();
        }
        
    }
}