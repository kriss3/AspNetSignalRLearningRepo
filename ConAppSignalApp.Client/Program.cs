namespace ConAppSignalApp.Client;

using Microsoft.AspNetCore.SignalR.Client;
using static System.Console;

public class Program
{
	static async Task Main()
	{
		WriteLine("Hello, World, from SignalR!");

		var hubUrl = "This will be my in-Solutons Hub url.";

		// Build the SignalR connection
		var connection = new HubConnectionBuilder()
			.WithUrl(hubUrl)
			.Build();

		// Register a handler to listen for messages from the hub
		connection.On<string>("ReceiveMessage", (message) =>
		{
			WriteLine($"Received message: {message}");
		});

		try
		{
			// Start the connection
			await connection.StartAsync();
			WriteLine("Connection started");

			// Keep the app running to listen for updates
			WriteLine("Listening for updates. Press any key to exit...");
			ReadKey();
		}
		catch (Exception ex)
		{
			WriteLine($"Error: {ex.Message}");
		}
		finally
		{
			await connection.DisposeAsync();
		}

	}
}
