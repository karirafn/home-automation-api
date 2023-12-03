namespace API.Zaptec.Features.GetChargeHistory;

public sealed record class ChargeData(
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
    IEnumerable<ChargeDatum> EnergyDetails,
    ChargerFirmwareVersion ChargerFirmwareVersion,
    string SignedSession);
