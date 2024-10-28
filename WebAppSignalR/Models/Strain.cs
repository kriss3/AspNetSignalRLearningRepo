namespace WebAppSignalR.Models;

public record Strain(
		int Id,
		Option<string> Name,
		Option<string> TestingStatus,
		Option<float> ThcLevel,
		Option<float> CbdLevel,
		float IndicaPercentage,
		float SativaPercentage,
		bool IsUsed,
		Option<string> Genetics
	);
