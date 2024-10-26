using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.HubApp.Hubs;

namespace SignalRDemo.HubApp.Controllers;

[ApiController]
[Route("api/data")]
public class DataController(IHubContext<DataHub> hubContext) : ControllerBase
{
	private readonly IHubContext<DataHub> _hubContext = hubContext;

	[HttpPost]
	public async Task<IActionResult> SendData([FromBody] string message)
	{
		await _hubContext.Clients.All.SendAsync("ReceiveData", message);
		return Ok(new { Message = "Data sent to clients" });
	}
}
