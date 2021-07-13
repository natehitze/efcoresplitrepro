using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RunMe
{
	class Program
	{
		private static Random _random = new();
		
		static async Task Main(string[] args)
		{
			const int workers = 8;
			
			Console.WriteLine("Waiting 5 seconds for API to start.");
			await Task.Delay(TimeSpan.FromSeconds(5));
			
			Console.WriteLine($"Starting {workers} requests...");
			var tasks = Enumerable.Range(0, workers).Select(_ => StartThread()).ToArray();
			Task.WaitAll(tasks);
		}

		private static async Task StartThread()
		{
			while (true)
			{
				var waitTime = _random.Next(3, 25);
				await Task.Delay(waitTime);
				await SendRequestAsync();
			}
		}

		private static async Task SendRequestAsync()
		{
			var url = $"https://localhost:5001/api/demo/getevents";

			var handler = new HttpClientHandler {ServerCertificateCustomValidationCallback = (_, _, _, _) => true};
			var httpClient = new HttpClient(handler);
			var response = await httpClient.GetAsync(url);
			response.EnsureSuccessStatusCode();
			Console.WriteLine("+");
		}
	}
}