using System;
using CQRS.Core.Events;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CQRS.Core.Domain
{
	public interface IEventStoreRepository
	{
		Task SaveAsync(EventModel @event);
		Task<List<EventModel>> FindByAggregateId(Guid aggregateId);
	}
}