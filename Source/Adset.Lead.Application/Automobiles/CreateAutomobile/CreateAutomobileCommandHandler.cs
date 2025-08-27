using Adset.Lead.Application.Abstractions.CQRSCommunication;
using Adset.Lead.Domain.Abstractions;

namespace Adset.Lead.Application.Automobiles.CreateAutomobile;

internal sealed class CreateAutomobileCommandHandler : ICommandHandler<CreateAutomobileCommand, Guid> 
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAutomobileCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Result<Guid>> Handle(CreateAutomobileCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}