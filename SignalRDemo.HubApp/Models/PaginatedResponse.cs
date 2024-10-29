using System.Collections.Generic;

namespace SignalRDemo.HubApp.Models;

public record PaginatedResponse<T>(
	List<T> Data,
	int Total,
	int TotalRecords,
	int PageSize,
	int RecordsOnPage,
	int Page,
	int CurrentPage,
	int TotalPages
);