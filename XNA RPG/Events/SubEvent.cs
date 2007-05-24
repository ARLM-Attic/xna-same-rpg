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
    public abstract class SubEvent
    {
        protected ContentManager content;
        protected bool isDone;

        public bool IsDone
        {
            get
            {
                return isDone;
            }
            set
            {
                isDone = value;
            }
        }

        public SubEvent(ContentManager content)
        {
            this.content = content;
            isDone = false;
        }

        public abstract bool Update(KeyboardState keyboard, Party party);

        public abstract void Draw(SpriteBatch spritebatch);



    }
}
