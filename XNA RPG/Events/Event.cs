using System;
using System.Collections.Generic;
using System.Text;

namespace XNA_RPG.Events
{
    public abstract class Event
    {
        private EventType type;

        public EventType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                type = value;
            }
        }

        public abstract void Trigger();
    }
}
