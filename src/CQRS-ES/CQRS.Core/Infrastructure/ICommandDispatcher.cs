using System;
using CQRS.Core.Commands;
using System.Threading.Tasks;

namespace CQRS.Core.Infrastructure
{
	public interface ICommandDispatcher
	{
		void RegisterHandler<T>(Func<T, Task> handler) where T : BaseCommand; // Func is delegate
		Task SendAsync(BaseCommand command);
	}
}