using CQRS.Core.Handlers;
using System.Threading.Tasks;
using Post.Cmd.Domain.Aggregates;

namespace Post.Cmd.Api.Commands
{
	public class CommandHandler : ICommandHandler
	{
		private IEventSourcingHandler<PostAggregate> _eventSourcingHandler { get; set; }

		public CommandHandler(IEventSourcingHandler<PostAggregate> eventSourcingHandler)
		{
			_eventSourcingHandler = eventSourcingHandler;
		}

		public async Task HandleAsync(NewPostCommand command)
		{
			var aggregate = new PostAggregate(command.Id, command.Author, command.Message);
			await _eventSourcingHandler.SaveAsync(aggregate);
		}

		public async Task HandleAsync(EditMessageCommand command)
		{
			var aggregate = await _eventSourcingHandler.GetByIdAsync(command.Id);
			aggregate.EditMessage(command.Message);

			await _eventSourcingHandler.SaveAsync(aggregate);
		}

		public async Task HandleAsync(LikePostCommand command)
		{
			var aggregate = await _eventSourcingHandler.GetByIdAsync(command.Id);
			aggregate.LikePost();

			await _eventSourcingHandler.SaveAsync(aggregate);
		}

		public async Task HandleAsync(AddCommentCommand command)
		{
			var aggregate = await _eventSourcingHandler.GetByIdAsync(command.Id);
			aggregate.AddComment(command.Comment, command.Username);

			await _eventSourcingHandler.SaveAsync(aggregate);
		}

		public async Task HandleAsync(EditCommentCommand command)
		{
			var aggregate = await _eventSourcingHandler.GetByIdAsync(command.Id);
			aggregate.EditComment(command.Id, command.Comment, command.Username);

			await _eventSourcingHandler.SaveAsync(aggregate);
		}

		public async Task HandleAsync(RemoveCommentCommand command)
		{
			var aggregate = await _eventSourcingHandler.GetByIdAsync(command.Id);
			aggregate.RemoveComment(command.Id, command.Username);

			await _eventSourcingHandler.SaveAsync(aggregate);
		}

		public async Task HandleAsync(DeletePostCommand command)
		{
			var aggregate = await _eventSourcingHandler.GetByIdAsync(command.Id);
			aggregate.DeletedPost(command.Username);

			await _eventSourcingHandler.SaveAsync(aggregate);
		}

        public async Task HandleAsync(RestoreDbCommand command)
        {
			await _eventSourcingHandler.RepublishEventsAsync();
        }
    }
}