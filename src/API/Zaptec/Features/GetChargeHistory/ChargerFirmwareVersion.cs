namespace API.Zaptec.Features.GetChargeHistory;

public sealed record ChargerFirmwareVersion(
    int Major,
    int Minor,
    int Build,
    int Revision,
    int MajorRevision,
    int MinorRevision);
