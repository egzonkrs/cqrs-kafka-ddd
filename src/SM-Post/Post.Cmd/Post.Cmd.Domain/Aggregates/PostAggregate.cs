using System;
using System.Collections.Generic;
using CQRS.Core.Domain;
using Post.Common.Events;

namespace Post.Cmd.Domain.Aggregates
{
	public class PostAggregate : AggregateRoot
	{
		private bool _active;
		private string _author;
		private readonly Dictionary<Guid, Tuple<string, string>> _comments = new();

		public bool Active
		{
			get => _active; set => _active = value;
		}

		public PostAggregate()
		{
		}

		public PostAggregate(Guid id, string author, string message)
		{
			RaiseEvent(new PostCreatedEvent
			{
				Id = id,
				Author = author,
				Message = message,
				DatePosted = DateTime.UtcNow
			});
		}

		public void Apply(PostCreatedEvent @event)
		{
			_id = @event.Id;
			_author = @event.Author;
			_active = true;
		}

		public void EditMessage(string message)
		{
			if (!_active) throw new InvalidOperationException("You cannot edit the message of an inactive post!");

			if (string.IsNullOrWhiteSpace(message))
			{
				throw new InvalidOperationException($"The value of {nameof(message)} cannot be null or empty. Please provide a valid {nameof(message)!}");
			}

			RaiseEvent(new MessageUpdatedEvent
			{
				Id = _id,
				Message = message
			});
		}

		public void Apply(MessageUpdatedEvent @event)
		{
			_id = @event.Id;
		}

		public void LikePost()
		{
			if (!_active) throw new InvalidOperationException("You cannot like an inactive post!");

			RaiseEvent(new PostLikedEvent
			{
				Id = _id,
			});
		}

		public void Apply(PostLikedEvent @event)
		{
			_id = @event.Id;
		}
	}
}