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

namespace XNA_RPG.Menu
{
    public class Menu
    {
        private Texture2D texture;
        private SpriteFont menuFont;
        private TimeSpan gameTime;
        private List<SubMenu> submenus;

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

        public List<SubMenu> Submenus
        {
            get
            {
                return submenus;
            }
            set
            {
                submenus = value;
            }
        }

        public Menu()
        {
            gameTime = new TimeSpan(0);
            submenus = new List<SubMenu>();
        }

        public void Draw(SpriteBatch spritebatch, TimeSpan time, Party party)
        {
            spritebatch.DrawString(menuFont, GetPlayTime(gameTime),
                new Vector2(640, 492), Color.White);

            foreach (SubMenu submenu in submenus)
            {
                spritebatch.DrawString(menuFont, submenu.Title,
                    new Vector2(650, 60 + submenus.IndexOf(submenu) * 20), Color.White);

                submenu.Draw(spritebatch, party, menuFont);
            }
        }

        public string GetPlayTime(TimeSpan time)
        {
            return ("Time: " + time.Hours + ":"
                + time.Minutes + ":" + time.Seconds);
        }

        public void UpdateGameTime(TimeSpan time)
        {
            gameTime += time;
        }
    }
}
