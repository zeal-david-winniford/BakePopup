using System.Collections.Immutable;
using BakePopup.Domain.Shared.DomainEvents;

namespace BakePopup.Domain.Shared;

/// <summary>
///   An entity that manages a group of related <see cref="Entity{TIdentifier}"/> objects.
/// </summary>
/// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
public abstract class AggregateRoot<TIdentifier>(TIdentifier id) : Entity<TIdentifier>(id)
{
    private readonly List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// Return all events and clear the underlying events collection.
    /// </summary>
    public ImmutableList<IDomainEvent> PullEvents()
    {
        var domainEvents = _domainEvents.ToImmutableList();
        _domainEvents.Clear();

        return domainEvents;
    }

    protected void PublishEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}