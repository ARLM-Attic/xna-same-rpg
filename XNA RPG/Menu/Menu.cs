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

        public void Draw(SpriteBatch spritebatch,TimeSpan playTime, Party party, string mapName)
        {
            spritebatch.DrawString(menuFont, GetPlayTime(playTime),
                new Vector2(640, 492), Color.White);

            spritebatch.DrawString(menuFont, mapName,
                new Vector2(520, 552), Color.White);

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

                if (handIndex == submenus.IndexOf(submenu) && subMenuActive == false)
                {
                    spritebatch.Draw(hand, new Rectangle(580, 60 + submenus.IndexOf(submenu) * 20, 60, 40), Color.White);
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

        public void UpdateMenu(KeyboardState keyboard, Party party)
        {
            if (subMenuActive == true)
            {
                bool stillActive = submenus[selectedIndex].UpdateSubMenu(keyboard, party);

                if (stillActive == false)
                {
                    subMenuActive = false;
                }
            }
            else
            {
                if (keyboard.IsKeyDown((Keys) Input.Input.Confirm))
                {
                    subMenuActive = true;
                    selectedIndex = handIndex;

                }
                else if (keyboard.IsKeyDown((Keys)Input.Input.Up) && handIndex != 0)
                {
                    handIndex--;
                }
                else if (keyboard.IsKeyDown((Keys)Input.Input.Down) && handIndex != submenus.Count - 1)
                {
                    handIndex++;
                }
                    
            }

        }
    }
}
