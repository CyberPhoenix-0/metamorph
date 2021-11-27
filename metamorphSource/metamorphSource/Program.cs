using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApplication3;

namespace metamorphSource
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            FindPage findPage = new FindPage("https://google.com/");
            await findPage.Find();
        }
    }
}