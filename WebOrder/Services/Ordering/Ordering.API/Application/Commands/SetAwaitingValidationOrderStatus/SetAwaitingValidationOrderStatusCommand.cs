using MediatR;
using System.Runtime.Serialization;

namespace WebOrder.Services.Ordering.API.Application.Commands
{
    public class SetAwaitingValidationOrderStatusCommand : IRequest<bool>
    {

        [DataMember]
        public int OrderNumber { get; private set; }

        public SetAwaitingValidationOrderStatusCommand(int orderNumber)
        {
            OrderNumber = orderNumber;
        }
    }
}
