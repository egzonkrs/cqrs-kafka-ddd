using CQRS.Core.Events;

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