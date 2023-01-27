using MediatR;
using System;

namespace Baas.Domain.Events
{
    public interface IEvent : INotification
    {
    }

    public interface IAuditEvent : IAuditEvent<Guid>
    {
    }

    public interface IAuditEvent<out T> : IEvent
    {
        T CorrelationId { get; }
        IAuditEvent AuditEvent { get; }
        Guid ParceiroId { get; }
        string Conta { get; }
    }
}