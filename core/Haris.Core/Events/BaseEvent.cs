using System;
using System.Collections.Generic;
using Haris.Core.Events.AttachedProperties;

namespace Haris.Core.Events
{
	public abstract class BaseEvent : IEvent
	{
		public Guid Id { get; protected set; }
		public IEnumerable<IAttachedProperty> AttachedProperties { get; protected set; }
		public string UserLocation { get; set; }

		protected BaseEvent()
		{
			Id = Guid.NewGuid();
		}
	}

	public abstract class BaseEvent<TPayload>: BaseEvent, IEvent<TPayload>
	{
		public TPayload Payload { get; protected set; }
		
		protected BaseEvent()
		{
		}

		protected BaseEvent(TPayload payload)
		{
			Payload = payload;
		}
	}
}