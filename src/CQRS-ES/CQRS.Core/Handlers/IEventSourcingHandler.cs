using System;
using System.Collections.Generic;
using CQRS.Core.Domain;
using System.Threading.Tasks;

namespace CQRS.Core.Handlers
{
	public interface IEventSourcingHandler<T>
	{
		Task SaveAsync(AggregateRoot aggregate);
		Task<T> GetByIdAsync(Guid id);
	}
}