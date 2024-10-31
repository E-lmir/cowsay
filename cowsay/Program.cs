using System.Net.Http.Json;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;

namespace cowsay
{
    internal class Program
    {
        private static HttpClient _httpClient => new HttpClient();
        private const string Cow = @"
    \
     \ ^__^
      \(oo)\________
       (__)\        )\/\
           ||-----w |
           ||      ||
            ";

        static async Task Main(string[] args)
        {
            var isLooped = false;
            var period = 0;
            if (args[0].StartsWith("-t:"))
            {
                isLooped = true;
                period = int.Parse(args[0].Split(':')[1]) * 1000;
                args[0] = string.Empty;
            }

            
            do
            {
                var cowMessageLeftBorder = "| ";
                var cowMessageRightBorder = " |";
                var cowMessage = cowMessageLeftBorder + (args[0]?.Length > 0 ? args[0] : await GetJoke()) + cowMessageRightBorder;
                var cowMessageLine = "+" + new string('-', cowMessage.Length - 2) + "+";
                await Task.Delay(period);

                Cowsole.WriteLine(cowMessageLine);
                Cowsole.WriteLine(cowMessage);
                Cowsole.Write(cowMessageLine);
                Cowsole.WriteLine(Cow);               
            }
            while (isLooped);
        }


        private static async Task<string> GetJoke()
        {
            var response = await _httpClient.GetAsync("https://geek-jokes.sameerkumar.website/api?format=json");
            var json = JsonSerializer.Deserialize<Joke>(await response.Content.ReadAsStringAsync());

            return json.joke;
        }

        public record Joke(string joke);
    }

}
