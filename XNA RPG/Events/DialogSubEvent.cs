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
    public class DialogSubEvent : SubEvent
    {
        public DialogSubEvent(ContentManager content)
            : base(content)
        {

        }

        public override void Draw(SpriteBatch spritebatch)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool Update(KeyboardState keyboard, Party party)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
