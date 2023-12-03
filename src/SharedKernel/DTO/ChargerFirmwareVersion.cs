namespace API.Zaptec.Features.GetChargeHistory;

public sealed record class ChargerFirmwareVersion(
    int Major,
    int Minor,
    int Build,
    int Revision,
    int MajorRevision,
    int MinorRevision);
