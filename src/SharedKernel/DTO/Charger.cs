namespace API.Zaptec.Features.GetChargers;

public sealed record class Charger(
    int OperatingMode,
    bool IsOnline,
    Guid Id,
    string MID,
    string DeviceId,
    string SerialNo,
    string Name,
    DateTime CreatedOnDate,
    Guid CircuitId,
    bool Active,
    int CurrentUserRoles,
    string Pin,
    int DeviceType,
    string InstallationName,
    Guid InstallationId,
    int AuthenticationType,
    bool IsAuthorizationRequired);
