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


namespace WindowsGame1.Submenus
{
    public class Main : SubMenu
    {
        private Texture2D emptyBar;
        private Texture2D fullBar;
        private SpriteFont smallFont;

        public Texture2D EmptyBar
        {
            get
            {
                return emptyBar;
            }
            set
            {
                emptyBar = value;
            }
        }

        public Texture2D FullBar
        {
            get
            {
                return fullBar;
            }
            set
            {
                fullBar = value;
            }
        }

        public SpriteFont SmallFont
        {
            get
            {
                return smallFont;
            }
            set
            {
                smallFont = value;
            }
        }

        public Main(string title, ContentManager content)
            : base(title, content)
        {
            smallFont = content.Load<SpriteFont>("Content\\Fonts\\Arial13");
            emptyBar = content.Load<Texture2D>("Content\\Menu\\EmptyBar");
            fullBar = content.Load<Texture2D>("Content\\Menu\\FullBar");
        }

        public override void Draw(SpriteBatch spritebatch, Party party, SpriteFont menuFont)
        {

            for (int i = 0; i < party.ActiveMembers.Count; i++)
            {

                Vector2 start = new Vector2(80, i * 150 + 100);
                Combatant comb = party.ActiveMembers[i];

                spritebatch.Draw(comb.Face, new Vector2(start.X + 5, start.Y + 5), Color.White);
                
                spritebatch.DrawString(menuFont, comb.Name, new Vector2(start.X + 200, start.Y + 10),
                    Color.White);

                spritebatch.DrawString(menuFont, "LV " + comb.Level, new Vector2(start.X + 340, start.Y + 10),
                    Color.White);

                spritebatch.DrawString(menuFont, "HP", new Vector2(start.X + 150, start.Y + 40), Color.White);
                spritebatch.DrawString(menuFont, "MP", new Vector2(start.X + 150, start.Y + 70), Color.White);
                spritebatch.DrawString(menuFont, "EXP", new Vector2(start.X + 150, start.Y + 100), Color.White);

                spritebatch.Draw(EmptyBar, new Rectangle((int)start.X + 210, (int)start.Y + 50, 200, 10), Color.White);
                spritebatch.Draw(EmptyBar, new Rectangle((int)start.X + 210, (int)start.Y + 80, 200, 10), Color.White);
                spritebatch.Draw(EmptyBar, new Rectangle((int)start.X + 210, (int)start.Y + 110, 200, 10), Color.White);

                int curHP = GetBarFill(comb.HP, comb.MaxHP);
                int curMP = GetBarFill(comb.MP, comb.MaxMP);
                int curEXP = GetBarFill(18, 100);

                spritebatch.Draw(FullBar, new Rectangle((int)start.X + 210, (int)start.Y + 50, curHP, 10), Color.White);
                spritebatch.Draw(FullBar, new Rectangle((int)start.X + 210, (int)start.Y + 80, curMP, 10), Color.White);
                spritebatch.Draw(FullBar, new Rectangle((int)start.X + 210, (int)start.Y + 110, curEXP, 10), Color.White);

                spritebatch.DrawString(smallFont, comb.HP + "/", new Vector2(start.X + 420, start.Y + 35), Color.Red);
                spritebatch.DrawString(smallFont, comb.MP + "/", new Vector2(start.X + 420, start.Y + 65), Color.Red);
                spritebatch.DrawString(smallFont, "18/", new Vector2(start.X + 420, start.Y + 95), Color.Red);

                spritebatch.DrawString(smallFont, comb.MaxHP.ToString(), new Vector2(start.X + 445, start.Y + 42), Color.Red);
                spritebatch.DrawString(smallFont, comb.MaxMP.ToString(), new Vector2(start.X + 445, start.Y + 72), Color.Red);
                spritebatch.DrawString(smallFont, "100", new Vector2(start.X + 445, start.Y + 102), Color.Red);
            }

            

        }

        public int GetBarFill(int current, int max)
        {
            float ratio = (float)current / (float)max;

            return ((int)(ratio * 200));
        }
    }
}
