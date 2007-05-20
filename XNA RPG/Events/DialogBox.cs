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
    public class DialogBox
    {
        private string message;
        private Texture2D background;
        private SpriteFont font;
        private ContentManager content;

        public DialogBox(string message, ContentManager content)
        {
            this.message = message;
            this.content = content;
            background = this.content.Load<Texture2D>("Content\\System\\DialogBox");
            font = this.content.Load<SpriteFont>("Content\\Fonts\\Arial13");
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            Vector2 msgSize = font.MeasureString(message);

            spritebatch.Draw(background, new Rectangle(200, 400,(int)msgSize.X + 30,(int)msgSize.Y + 40), Color.White);

            spritebatch.DrawString(font, message, new Vector2(215, 420), Color.White);

        }


    }
}
