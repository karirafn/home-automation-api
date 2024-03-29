﻿namespace SharedKernel.DTO;

public sealed record class GetChargerByIdResponse(
    int OperationMode,
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
    bool PropertyPinOfflinePhase,
    bool PropertyAuthenticationDisabled,
    bool HasSessions,
    int PropertyOfflinePhaseOverride,
    double SignedMeterValueKwh,
    string SignedMeterValue,
    int DeviceType,
    string InstallationName,
    Guid InstallationId,
    int AuthenticationType,
    bool IsAuthorizationRequired);
