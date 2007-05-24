using System;
using System.Collections.Generic;
using System.Text;

namespace XNA_RPG.Events
{
    public class OnTouchEvent : Event
    {
        public OnTouchEvent()
            : base()
        {
            base.Type = EventType.OnTouch; 
        }


    }
}
