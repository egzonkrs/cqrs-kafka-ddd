using System;
using System.Linq;
using CQRS.Core.Domain;
using CQRS.Core.Handlers;
using System.Threading.Tasks;
using CQRS.Core.Infrastructure;
using Post.Cmd.Domain.Aggregates;

namespace Post.Cmd.Infrastructure.Handlers
{
	public class EventSourcingHandler : IEventSourcingHandler<PostAggregate>
	{
		private readonly IEventStore _eventStore;

		public EventSourcingHandler(IEventStore eventStore)
		{
			_eventStore = eventStore;
		}

		public async Task<PostAggregate> GetByIdAsync(Guid aggregateId)
		{
			var aggregate = new PostAggregate();
			var events = await _eventStore.GetEventsAsync(aggregateId);

			if (events is null || !events.Any()) return aggregate;

			aggregate.ReplayEvents(events);
			aggregate.Version = events.Select(x => x.Version).Max();

			return aggregate;
		}

		public async Task SaveAsync(AggregateRoot aggregate)
		{
			await _eventStore.SaveEventsAsync(aggregate.Id, aggregate.GetUncommitedChanges(), aggregate.Version);
			aggregate.MarkChangesAsCommitted();
		}
	}
}