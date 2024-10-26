namespace ConAppSignalApp.Client;

using ConAppSignalApp.Client.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;

using static System.Console;

public class Program
{
	static async Task Main()
	{
		const string localApiUrl = @"https://localhost:7254/dataHub";
		WriteLine("Hello, World, from SignalR!");
		var config = BuildAppConfig();

		var appSettings = new AppSettingsModel();
		config.GetSection("SignalR").Bind(appSettings);
		var hubUrl = appSettings.HubUrl;

		// Build the SignalR connection
		var connection = new HubConnectionBuilder()
			.WithUrl(hubUrl ?? localApiUrl)
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

	private static IConfiguration BuildAppConfig()
	{
		var configuration = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			.Build();

		return configuration;
	}
}
