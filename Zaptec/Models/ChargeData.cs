namespace Zaptec.Models;

public record ChargeData(
    Guid Id,
    string DeviceId,
    DateTime StartDateTime,
    DateTime EndDateTime,
    double Energy,
    int CommitMetadata,
    DateTime CommitEndDateTime,
    Guid ChargerId,
    string DeviceName,
    bool ExternallyEnded,
    IEnumerable<EnergyDetail> EnergyDetails,
    ChargerFirmwareVersion ChargerFirmwareVersion,
    string SignedSession);
