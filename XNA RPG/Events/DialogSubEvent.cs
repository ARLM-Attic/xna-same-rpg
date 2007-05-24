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

        private DialogBox dialog;

        private Keys waitingKey;

        public DialogSubEvent(ContentManager content, string message)
            : base(content)
        {
            dialog = new DialogBox(content, message);
        }

        public DialogSubEvent(ContentManager content, string message, string name, string faceName)
            : base(content)
        {
            dialog = new SpokenDialogBox(content, message, name, faceName);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            dialog.Draw(spritebatch);
        }

        public override bool Update(KeyboardState keyboard, Party party)
        {
            if (keyboard.IsKeyDown((Keys)Input.Input.Confirm))
            {
                waitingKey = (Keys)Input.Input.Confirm;
            }
            else if (waitingKey == (Keys)Input.Input.Confirm
                && keyboard.IsKeyUp((Keys)Input.Input.Confirm))
            {
                isDone = true;
            }

            return isDone;
        }
    }
}
