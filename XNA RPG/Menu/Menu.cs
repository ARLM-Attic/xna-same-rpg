using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using XNA_RPG.Map;
using XNA_RPG.Character;
using XNA_RPG.Menu;

namespace XNA_RPG.Menu
{
    public class Menu
    {
        private Texture2D texture;
        private SpriteFont menuFont;
        private TimeSpan gameTime;

        public Texture2D Texture
        {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
            }
        }

        public SpriteFont MenuFont
        {
            get
            {
                return menuFont;
            }
            set
            {
                menuFont = value;
            }
        }

        public Menu()
        {
            gameTime = new TimeSpan(0);
        }

        public void Draw(SpriteBatch spritebatch, TimeSpan time)
        {
            this.gameTime += time;

   

            spritebatch.DrawString(menuFont, GetPlayTime(gameTime),
                new Vector2(600, 492), Color.White);
        }

        public string GetPlayTime(TimeSpan time)
        {
            return ("Playtime: " + time.Hours + ":" 
                + time.Minutes + ":" + time.Seconds);
        }
    }
}
