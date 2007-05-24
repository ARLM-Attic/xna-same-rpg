using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using XNA_RPG.Mapping;
using XNA_RPG.Character;
using XNA_RPG.Menu;
using XNA_RPG.Input;

namespace XNA_RPG.Events
{
    public class Event
    {
        private EventType type;
        private SubEvent currentSubEvent;
        private bool IsDone;
        private List<SubEvent> subevents;

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

        public Event()
        {

            subevents = new List<SubEvent>();
        }

        public List<SubEvent> SubEvents
        {
            get
            {
                return subevents;
            }
            set
            {
                subevents = value;
            }
        }

        public bool Update(KeyboardState keyboard, Party party)
        {
            return true;
        }

        public void Draw(SpriteBatch spritebatch)
        {
        }



    }
}
