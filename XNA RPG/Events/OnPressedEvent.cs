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

        public override void Trigger()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
