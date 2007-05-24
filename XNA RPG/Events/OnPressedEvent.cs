using System;
using System.Collections.Generic;
using System.Text;

namespace XNA_RPG.Events
{
    public class OnPressedEvent : Event
    {
        public OnPressedEvent()
            : base()
        {
            base.Type = EventType.OnPressed;
        }
    }
}
