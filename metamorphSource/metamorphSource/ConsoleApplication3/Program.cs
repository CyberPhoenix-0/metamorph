using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApplication3
{

    internal class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Write("Entrez l'adresse URL du site web : ");
            string url = Console.ReadLine();
            
            FileStream log = File.Create(@"C:\Users\Jupiter\Desktop\project\log.txt");
            StreamReader streamReader = new StreamReader(@"C:\Users\Jupiter\Desktop\project\common.txt");
            string ligne;
            List<string> found = new List<string>();

            while ((ligne = await streamReader.ReadLineAsync()) != null)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), url + ligne ))
                    {
                        var response = await httpClient.SendAsync(request);
                        Console.WriteLine(url + ligne + "\t Status: " + response.StatusCode);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            found.Add(url + ligne + "\t Status: " + response.StatusCode);
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
