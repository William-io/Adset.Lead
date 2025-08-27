using System.Windows.Input;
using Adset.Lead.Application.Abstractions.CQRSCommunication;

namespace Adset.Lead.Application.Automobiles.CreateAutomobile;

public sealed record CreateAutomobileCommand(
    string Brand,
    string Model,
    int Year,
    string Plate,
    string Color,
    decimal Price,
    int? Km,
    IReadOnlyCollection<string>? OptionalFeatures,
    IReadOnlyCollection<string>? PhotoUrls) : ICommand<Guid>;