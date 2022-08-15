using System;
using CQRS.Core.Events;

namespace Post.Common.Events
{
	public class RemovedCommentEvent : BaseEvent
	{
		public Guid CommentId { get; set; }
		public string Comment { get; set; }
		public string Username { get; set; }
		public DateTime EditDate { get; set; }

		public RemovedCommentEvent() : base(nameof(RemovedCommentEvent))
		{
		}
	}
}