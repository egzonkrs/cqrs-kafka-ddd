using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Common.Events
{
	public class PostLikedEvent : BaseEvent
	{
		public string Message { get; set; }

		public PostLikedEvent() : base(nameof(PostLikedEvent))
		{
		}
	}
}