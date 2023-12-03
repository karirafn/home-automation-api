using API.Zaptec.Features.GetChargeHistory;
using API.Zaptec.Features.GetChargerById;
using API.Zaptec.Features.GetChargers;
using API.Zaptec.Features.GetChargerState;
using API.Zaptec.Features.GetCost;
using API.Zaptec.Features.GethargeHistoryCostSummary;

using Microsoft.AspNetCore.Mvc;

using SharedKernel.DTO;

namespace API.Zaptec.Configuration;

internal static class ZaptecEndpoints
{
    public static void MapZaptecEndpoints(this WebApplication app)
    {
        RouteGroupBuilder zaptec = app
            .MapGroup("/api/zaptec")
            .WithOpenApi();

        zaptec.MapGet("chargers", async ([FromServices] GetChargersHandler handler) =>
        {
            GetChargersResponse response = await handler.HandleAsync(default);
            return TypedResults.Ok(response.Data);
        });

        zaptec.MapGet("chargers/{id}", async (
            [FromRoute] Guid id,
            [FromServices] GetChargerByIdHandler handler) =>
        {
            GetChargerByIdResponse? response = await handler.HandleAsync(id, default);

            return response is not null ? TypedResults.Ok(response) : Results.NotFound();
        });

        zaptec.MapGet("chargers/{id}/state", async (
            [FromRoute] Guid id,
            [FromServices] GetChargerStateHandler handler) =>
        {
            IReadOnlyCollection<ChargerState>? response = await handler.HandleAsync(id, default);

            return response.Count > 0 ? TypedResults.Ok(response) : Results.NotFound();
        });

        zaptec.MapGet("chargers/history", async ([FromServices] GetChargeHistoryHandler handler) =>
        {
            GetChargeHistoryResponse response = await handler.HandleAsync(default);
            return TypedResults.Ok(response.Data);
        });

        zaptec.MapGet("chargers/history/cost", async ([FromServices] GetChargeHistoryCostHandler handler) =>
        {
            IEnumerable<ChargeCost> response = await handler.HandleAsync(default);
            return TypedResults.Ok(response);
        });

        zaptec.MapGet("chargers/history/cost/summary", async (
            [FromServices] GetChargeHistoryCostSummaryHandler handler,
            [FromQuery] string groupby = "month") =>
        {
            IEnumerable<ChargeCostSummary> response = await handler.HandleAsync(groupby, default);
            return TypedResults.Ok(response);
        });
    }
}
