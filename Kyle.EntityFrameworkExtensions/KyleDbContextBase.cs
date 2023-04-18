using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Kyle.EntityFrameworkExtensions;

public class KyleDbContextBase : DbContext
{
    public KyleDbContextBase(DbContextOptions<KyleDbContextBase> options) : base(options)
    {
    }

    protected KyleDbContextBase(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        MappingEntityTypes(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private void MappingEntityTypes(ModelBuilder modelBuilder)
    {
        var assemblies = Kyle.Extensions.AssemblyExtensions.GetAssemblies();

        var types = assemblies.SelectMany(x =>
            x.GetTypes().Where(c => c.GetCustomAttributes<TableAttribute>().Any()).ToArray());
        var list = types?.Where(x => x.IsClass && !x.IsAbstract && !x.IsGenericType).ToList();

        if (list != null && list.Any())
        {
            foreach (var item in list)
            {
                modelBuilder.Entity(item);
            }
        }
    }
}

//public class KyleDbContext : DbContext
//{
//    public KyleDbContext(DbContextOptions<KyleDbContext> options) : base(options)
//    {

//    }
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        MappingEntityTypes(modelBuilder);
//        base.OnModelCreating(modelBuilder);
//    }

//    private void MappingEntityTypes(ModelBuilder modelBuilder)
//    {
//        var assemblies = Kyle.Extensions.AssemblyExtensions.GetAssemblies();

//        var types = assemblies.SelectMany(x =>
//            x.GetTypes().Where(c => c.GetCustomAttributes<TableAttribute>().Any()).ToArray());
//        var list = types?.Where(x => x.IsClass && !x.IsAbstract && !x.IsGenericType).ToList();

//        if (list != null && list.Any())
//        {
//            foreach (var item in list)
//            {
//                modelBuilder.Entity(item);
//            }
//        }
//    }



//    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
//    {
//        var entities = ChangeTracker.Entries()
//            .Where(x => x.Entity is AggregateRoot && ((AggregateRoot)x.Entity).DomainEvents.Any())
//            .Select(x => (AggregateRoot)x.Entity).ToList();

//        foreach (var item in entities)
//        {
//            //var messageData = new MessageData { CommandName = item.GetType().FullName, MessageDataBody = JToken.FromObject(item) };
//            //commandSender.PublishMessage(messageData);
//            await TriggerDomainEvents(item);
//        }

//        return await base.SaveChangesAsync(cancellationToken);
//    }

//    private async Task TriggerDomainEvents(AggregateRoot aggregateRoot)
//    {
//        var domainEvents = aggregateRoot.DomainEvents.ToList();
//        aggregateRoot.DomainEvents.Clear();

//        foreach (var domainEvent in domainEvents)
//        {
//            if (!domainEvent.IsPublisher)
//            {
//                // _logger.LogInformation($"Event Send:{domainEvent}");
//                // await _mediator.Publish(domainEvent);
//                // await _eventBus.Send(domainEvent);
//            }
//            // else if (domainEvent.IsPublisher)
//            //     await _capPublisher.PublishAsync("Q-Test",domainEvent);
//        }
//    }


//}