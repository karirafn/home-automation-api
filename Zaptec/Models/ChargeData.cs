namespace Zaptec.Models
{
    public record ChargeData(
        Guid Id,
        String DeviceId,
        DateTime StartDateTime,
        DateTime EndDateTime,
        double Energy,
        int CommitMetadata,
        DateTime CommitEndDateTime,
        Guid ChargerId,
        string DeviceName,
        bool ExternallyEnded,
        ChargerFirmwareVersion ChargerFirmwareVersion,
        string SignedSession);
}
