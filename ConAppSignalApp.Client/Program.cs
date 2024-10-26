namespace ConAppSignalApp.Client;

using Microsoft.AspNetCore.SignalR.Client;
using static System.Console;

public class Program
{
	static async Task Main()
	{
		WriteLine("Hello, World, from SignalR!");

		var hubUrl = "https://localhost:7254/dataHub"; // if this works move the url to appsettings.json

		// Build the SignalR connection
		var connection = new HubConnectionBuilder()
			.WithUrl(hubUrl)
			.Build();

		// Register a handler to listen for messages from the hub. 
		// IMPORTANT: The method name must match the method name defined in the hub.
		connection.On<string>("ReceiveData", (message) =>
		{
			WriteLine("Received data: " + message);
		});

		try
		{
			// Start the connection
			await connection.StartAsync();
			WriteLine("Connection started...");

			// Keep the app running to listen for updates
			WriteLine("Connected to the Server. \nListening for updates. Press any key to exit...");
			ReadLine();
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
