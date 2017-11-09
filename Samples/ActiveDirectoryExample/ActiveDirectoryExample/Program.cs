using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectoryExample
{
    class Program
    {
        private const string HOWDY_API_URL = "https://wlb-uat-ne1-api.azurewebsites.net/";
        //INFO: Use this const for production
        //private const string HOWDY_API_URL = "https://api-ne1.worklifebarometer.com/";

        //TODO: Insert your JWT token here. Can be obtained from the portal
        private const string HOWDY_API_TOKEN = "";
        //TODO: Insert your Howdy Company ID here
        private const int HOWDY_COMPANY_ID = 100000;

        static void Main(string[] args)
        {
            Task.Run(StartAsync).GetAwaiter().GetResult();
        }


        private static async Task StartAsync()
        {
            //TODO: Choose your system/implementatino of choice
            IHRSystem hrSystem = new ActiveDirectoryImplementation();
            //IHRSystem hrSystem = new SqlServerImplementation();

            var employeeData = await hrSystem.GetAllHowdyUsersAsync();

            Console.WriteLine("Howdy Data to be posted:");
            Console.WriteLine(employeeData);

            Console.WriteLine("Posting data");
            await SendDataToHowdyAsync(employeeData);

            Console.WriteLine("Done. Press [Enter] to exit");
            Console.ReadLine();
        }

        private static async Task SendDataToHowdyAsync(JToken howdyPayload)
        {


            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HOWDY_API_TOKEN);
            httpClient.BaseAddress = new Uri(HOWDY_API_URL);
            var response = await httpClient.PutAsync($"/v1.0/Company/{HOWDY_COMPANY_ID}/Employee", 
                new StringContent(howdyPayload.ToString(), Encoding.UTF8, "application/json"));


            Console.WriteLine("Response from Howdy");
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }

        

        
    }
}
