using Kyle.Infrastructure.Events;
using Microsoft.EntityFrameworkCore;

namespace Kyle.EntityFrameworkExtensions.Test.DbContextes;

public class MallDbContextTest: KyleDbContextBase
{
    
    // private readonly IEventBus _eventBus;

    public MallDbContextTest(DbContextOptions<MallDbContextTest> options
        // , IEventBus eventBus
        ) : base(options)
    {
        // _eventBus = eventBus;
    }
    
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x.Entity is AggregateRoot && ((AggregateRoot)x.Entity).DomainEvents.Any())
            .Select(x => (AggregateRoot)x.Entity).ToList();

        foreach (var item in entities)
        {
            //var messageData = new MessageData { CommandName = item.GetType().FullName, MessageDataBody = JToken.FromObject(item) };
            //commandSender.PublishMessage(messageData);
            await TriggerDomainEvents(item);
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    private async Task TriggerDomainEvents(AggregateRoot aggregateRoot)
    {
        var domainEvents = aggregateRoot.DomainEvents.ToList();
        aggregateRoot.DomainEvents.Clear();

        foreach (var domainEvent in domainEvents)
        {
            if (!domainEvent.IsPublisher)
            {
                // _logger.LogInformation($"Event Send:{domainEvent}");
                // await _mediator.Publish(domainEvent);
                // await _eventBus.Send(domainEvent);
            }
            // else if (domainEvent.IsPublisher)
            //     await _capPublisher.PublishAsync("Q-Test",domainEvent);
        }
    }
}