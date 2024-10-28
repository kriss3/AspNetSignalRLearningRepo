using System.Collections.Generic;

namespace WebAppSignalR.Models;

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