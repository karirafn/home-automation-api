namespace Zaptec.Models
{
    public record ChargeHistory(int Pages, IEnumerable<ChargeData> Data);
}
