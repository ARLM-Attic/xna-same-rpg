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
        #region Variables

        private Texture2D texture;
        private Texture2D hand;
        private SpriteFont menuFont;
        private TimeSpan gameTime;
        private List<SubMenu> submenus;
        private SubMenu mainSubmenu;
        private int selectedIndex;
        private int handIndex;
        private bool subMenuActive;

        #endregion

        #region Accessors
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

        public Texture2D Hand
        {
            get
            {
                return hand;
            }
            set
            {
                hand = value;
            }
        }

        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
            }
        }

        public int HandIndex
        {
            get
            {
                return handIndex;
            }
            set
            {
                handIndex = value;
            }
        }

        public bool SubMenuActive
        {
            get
            {
                return subMenuActive;
            }
            set
            {
                subMenuActive = value;
            }
        }

        public SubMenu MainSubMenu
        {
            get
            {
                return mainSubmenu;
            }
            set
            {
                mainSubmenu = value;
            }
        }

        #endregion


        public Menu()
        {
            gameTime = new TimeSpan(0);
            submenus = new List<SubMenu>();
            handIndex = 0;
        }

        public void Draw(SpriteBatch spritebatch, TimeSpan time, Party party)
        {
            spritebatch.DrawString(menuFont, GetPlayTime(gameTime),
                new Vector2(640, 492), Color.White);

            if (subMenuActive == false)
            {
                mainSubmenu.Draw(spritebatch, party, menuFont);
            }

            foreach (SubMenu submenu in submenus)
            {
                spritebatch.DrawString(menuFont, submenu.Title,
                    new Vector2(650, 60 + submenus.IndexOf(submenu) * 20), Color.White);

                if (selectedIndex == submenus.IndexOf(submenu) && subMenuActive == true)
                {
                    submenu.Draw(spritebatch, party, menuFont);
                }

                if (handIndex == submenus.IndexOf(submenu))
                {
                    spritebatch.Draw(hand, new Vector2(500, 55 + submenus.IndexOf(submenu) * 20), Color.White);
                }
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

        public void UpdateMenu(KeyboardState keyboard)
        {
            if (subMenuActive == true)
            {
                bool stillActive = submenus[selectedIndex].UpdateSubMenu(keyboard);

                if (stillActive == false)
                {
                    subMenuActive = false;
                }
            }
            else
            {
                if (keyboard.IsKeyDown(Keys.F))
                {
                    subMenuActive = true;
                    selectedIndex = handIndex;
                }
                else if (keyboard.IsKeyDown(Keys.Up) && handIndex != 0)
                {
                    handIndex--;
                }
                else if (keyboard.IsKeyDown(Keys.Down) && handIndex != submenus.Count - 1)
                {
                    handIndex++;
                }
                    
            }

        }
    }
}
