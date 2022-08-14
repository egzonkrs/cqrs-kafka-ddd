using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Common.Events
{
	public class PostUpdatedEvent : BaseEvent
	{
		public string Message { get; set; }

		public PostUpdatedEvent() : base(nameof(PostUpdatedEvent))
		{
		}
	}
}