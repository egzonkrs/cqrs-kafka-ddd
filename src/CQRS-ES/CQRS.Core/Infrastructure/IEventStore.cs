using System;
using CQRS.Core.Events;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CQRS.Core.Infrastructure
{
	public interface IEventStore
	{
		Task SaveEventsAsync(Guid aggregateId, IEnumerable<BaseEvent> events, int expectedVersion);
		Task<List<BaseEvent>> GetEventsAsync(Guid aggregateId);
	}
}