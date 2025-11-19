using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using GenerativeAI;

namespace NepaliInvestmentAdvisor
{
    class Program
    {
        // Simulated in-memory cache for pre-generated advice
        private static readonly ConcurrentDictionary<string, string> AdviceCache = new ConcurrentDictionary<string, string>();

        static async Task Main(string[] args)
        {

            string apiKey = "AIzaSyA3_UeAEtKc5GlIV0fHeWrIITmI6sGiJIE";

            var client = new GenerativeModel(apiKey, "gemini-2.5-flash-lite");

            // Example user prompts (financial scenarios)
            string[] userPrompts =
            {
                "How can i watch NPL season 2 live for free in Nepal?"

            };

            foreach (var prompt in userPrompts)
            {
                Console.WriteLine(DateTime.Now.Second);
                Console.WriteLine($"\nUser Prompt: {prompt}");

                if (AdviceCache.TryGetValue(prompt, out var cachedAdvice))
                {
                    // Instant response from cache
                    Console.WriteLine("AI Response (cached):");
                    Console.WriteLine(cachedAdvice);
                }
                else
                {
                    // Start background AI call
                    Console.WriteLine("AI Response: Processing...");

                    _ = Task.Run(async () =>
                    {
                        try
                        {

                            var response = await client.GenerateContentAsync(prompt);
                            var text = response.Text.Trim();

                            // Save to cache for future requests
                            AdviceCache[prompt] = text;

                            // Simulate notifying UI / console when done
                            Console.WriteLine($"\nAI Response (generated):\n{text}\n");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error generating AI response: {ex.Message}");
                        }
                    });
                }
            }
            Console.WriteLine("\nPress Enter to exit...");
            Console.WriteLine(DateTime.Now.Second);
            Console.ReadLine();
        }
    }

}
