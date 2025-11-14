using System;
using System.Threading.Tasks;
using GenerativeAI;

namespace NepaliInvestmentAdvisor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string apiKey = "AIzaSyA3_UeAEtKc5GlIV0fHeWrIITmI6sGiJIE";

            var client = new GenerativeModel(apiKey ,"gemini-2.5-pro");

            // Example user data
            // double income = 50000;
            // double expenses = 35000;
            // string riskTolerance = "medium";
            // string goal = "long-term growth";
            string prompt = "Giv me 4 ideas for Final Year Projects";
            Console.Write("Hello");
            var response = await client.GenerateContentAsync(prompt);
            Console.WriteLine(response.Text);
            
            
            
            
            Console.ReadLine();
        }
    }
}