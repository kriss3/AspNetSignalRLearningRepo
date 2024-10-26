using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo.HubApp.Hubs;

public class DataHub : Hub
{
	public async Task BroadcastData(string data)
	{
		await Clients.All.SendAsync("From DataHub, ReceivedData:", data);
	}
}
