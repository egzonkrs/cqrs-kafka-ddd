using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Common.Events
{
	public class CommentAddedEvent : BaseEvent
	{
		public Guid CommentId { get; set; }
		public string Comment { get; set; }
		public string Username { get; set; }
		public DateTime CommentDate { get; set; }

		public CommentAddedEvent() : base(nameof(CommentAddedEvent))
		{
		}
	}
}