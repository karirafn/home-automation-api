namespace API.Zaptec;

public class ZaptecOptions
{
    public const string Zaptec = nameof(Zaptec);
    public const string AccessTokenCacheKey = "ZaptecAccessToken";
    public const string ChargeHistoryCacheKey = "ZaptecChargeHistory";

    public string ApiRoot { get; init; } = string.Empty;
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
