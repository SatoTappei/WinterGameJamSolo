using MessagePipe;
using VContainer;
using VContainer.Unity;

public class InGameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        MessagePipeOptions options = builder.RegisterMessagePipe();
        builder.RegisterMessageBroker<StickData>(options);
    }
}
