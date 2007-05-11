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
    public class SubMenu
    {

        private string title;
        private ContentManager content;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public SubMenu(string title, ContentManager content)
        {
            this.title = title;
            this.content = content;
        }

        public virtual void Draw(SpriteBatch spritebatch, Party party, SpriteFont spriteFont)
        {
        }

        public virtual bool UpdateSubMenu(KeyboardState keyboard)
        {
            return false;
        }

    }
}
