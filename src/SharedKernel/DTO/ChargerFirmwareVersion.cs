namespace SharedKernel.DTO;

public sealed record class ChargerFirmwareVersion(
    int Major,
    int Minor,
    int Build,
    int Revision,
    int MajorRevision,
    int MinorRevision);
