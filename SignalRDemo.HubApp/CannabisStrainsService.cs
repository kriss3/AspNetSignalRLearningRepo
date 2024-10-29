using Functional;
using SignalRDemo.HubApp.Models;

namespace SignalRDemo.HubApp;

public interface IStrainsApiClient
{
	Task<Option<Strain>> GetStrainByIdAsync(int id, string licenseNumber);
	Task<Option<PaginatedResponse<Strain>>> GetActiveStrainsAsync(string licenseNumber, DateTime? lastModifiedStart, DateTime? lastModifiedEnd, int? pageNumber, int? pageSize);
	Task<Option<PaginatedResponse<Strain>>> GetInactiveStrainsAsync(string licenseNumber, int? pageNumber, int? pageSize);
}

public class CannabisStrainsService
{
}
