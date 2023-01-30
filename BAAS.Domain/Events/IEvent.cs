using MediatR;
using System;

namespace Baas.Domain.Events
{
    public interface IEvent : INotification
    {
        Guid CorrelationId { get; }
        string QueueName { get; }
    }
}