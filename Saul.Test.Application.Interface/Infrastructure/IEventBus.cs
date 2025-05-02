namespace Saul.Test.Application.Interface.Infrastructure
{
    public interface IEventBus
    {
        void Publish<T>(T @event);
    }
}
