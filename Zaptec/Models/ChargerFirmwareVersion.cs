namespace Zaptec.Models;

    public record ChargerFirmwareVersion(
            int Major,
            int Minor,
            int Build,
            int Revision,
            int MajorRevision,
            int MinorRevision);
}
