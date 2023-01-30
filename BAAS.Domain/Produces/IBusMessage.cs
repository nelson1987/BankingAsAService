using Baas.Domain.Events;

namespace BAAS.Domain.Produces
{
    public interface IBusMessage
    {
        void Init(IEvent message);
    }
}
