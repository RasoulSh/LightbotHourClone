namespace LightbotHour.Common.Mediator
{
    public interface IEventHandler<T> : IMediatorHandler where T : IEvent
    {
        void Handle(T data);
    }

}