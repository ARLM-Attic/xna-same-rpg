using System;
using System.Collections.Generic;
using System.Collections;
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
    public class Items : SubMenu
    {
        private enum Choice { Use = 0, Sort = 1, Discard = 2, None = 3 };
        private Texture2D background;
        private Texture2D hand;
        private Texture2D emptyBar;
        private Texture2D fullBar;
        private SpriteFont spriteFont;
        private SpriteFont smallFont;
        private int handIndex;
        private int subIndex;
        private Choice subActive;
        private List<string> inventory;
        private Keys[] pressedKeys;


        public Items(string title, ContentManager content)
            : base(title, content)
        {
            background = content.Load<Texture2D>("Content\\Menu\\ItemsBackground");
            hand = content.Load<Texture2D>("Content\\Menu\\menuHand");
            emptyBar = content.Load<Texture2D>("Content\\Menu\\EmptyBar");
            fullBar = content.Load<Texture2D>("Content\\Menu\\FullBar");
            spriteFont = content.Load<SpriteFont>("Content\\Fonts\\Arial13");
            smallFont = content.Load<SpriteFont>("Content\\Fonts\\Arial9");
            handIndex = (int)Choice.Use;
            subActive = Choice.None;
            subIndex = 0;
            pressedKeys = new Keys[0];
        }

        public override void Draw(SpriteBatch spritebatch, Party party, SpriteFont spriteFont)
        {

            inventory = GetItems(party);

            foreach (DictionaryEntry item in party.Bag.Items)
            {
                inventory.Add((string)item.Key);
            }

            spritebatch.Draw(background, new Rectangle(20, 0, 600, 600), Color.White);

            spritebatch.DrawString(spriteFont, "Use", new Vector2(180, 20), Color.White);
            spritebatch.DrawString(spriteFont, "Sort", new Vector2(280, 20), Color.White);
            spritebatch.DrawString(spriteFont, "Discard", new Vector2(380, 20), Color.White);

            spritebatch.Draw(hand, new Rectangle(handIndex * 100 + 120, 20, 60, 40), Color.White);


            for (int i = 0; i < inventory.Count; i++)
            {

                spritebatch.DrawString(spriteFont, inventory[i], new Vector2(380, i * 25 + 100), Color.White);

            }

            DrawCharacters(spritebatch, party);



        }

        public List<string> GetItems(Party party)
        {
            List<string> items = new List<string>();

            IDictionaryEnumerator ie = party.Bag.Accessories.GetEnumerator();

            foreach (DictionaryEntry item in party.Bag.Accessories)
            {
                items.Add((string)item.Key);
            }

            foreach (DictionaryEntry item in party.Bag.Armors)
            {
                items.Add((string)item.Key);
            }

            foreach (DictionaryEntry item in party.Bag.Helms)
            {
                items.Add((string)item.Key);
            }

            foreach (DictionaryEntry item in party.Bag.Shields)
            {
                items.Add((string)item.Key);
            }

            foreach (DictionaryEntry item in party.Bag.Weapons)
            {
                items.Add((string)item.Key);
            }

            foreach (DictionaryEntry item in party.Bag.Items)
            {
                items.Add((string)item.Key);
            }

            return items;
        }

        public override bool UpdateSubMenu(KeyboardState keyboard)
        {

            

            List<Keys> keys = new List<Keys>();

            foreach (Keys k in pressedKeys)
            {
                if (keyboard.IsKeyUp(k))
                {
                    keys.Add(k);
                }
            }

            pressedKeys = keyboard.GetPressedKeys();

            if (keys.Count > 0)
            {
                if (keys[0] == (Keys.Back))
                {

                    return false;
                }
                else if (keys[0] == (Keys.Left))
                {
                    if (handIndex != 0)
                    {
                        handIndex--;
                    }

                    return true;
                }
                else if (keys[0] == (Keys.Right))
                {
                    if (handIndex < 2)
                    {
                        handIndex++;
                    }

                    return true;
                }
                else if (keys[0] == (Keys.Up))
                {
                    if (subActive != Choice.None && subIndex < inventory.Count - 1)
                    {
                        subIndex++;
                    }

                    return true;
                }
                else if (keys[0] == (Keys.Down))
                {
                    if (subActive != Choice.None && subIndex > 0)
                    {
                        subIndex--;
                    }

                    return true;
                }
                else if (keys[0] == (Keys.F))
                {


                    return true;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                return true;
            }

            
        }

        public void DrawCharacters(SpriteBatch spritebatch, Party party)
        {
            for (int i = 0; i < party.ActiveMembers.Count; i++)
            {

                Vector2 start = new Vector2(40, i * 150 + 120);
                Combatant comb = party.ActiveMembers[i];

                spritebatch.Draw(comb.Face, new Rectangle((int)start.X, (int)start.Y, 92, 92), Color.White);

                spritebatch.DrawString(spriteFont, comb.Name, new Vector2(start.X + 100, start.Y),
                    Color.White);

                spritebatch.DrawString(spriteFont, "LV " + comb.Level, new Vector2(start.X + 190, start.Y),
                    Color.White);

                spritebatch.DrawString(spriteFont, "HP", new Vector2(start.X + 100, start.Y + 30), Color.White);
                spritebatch.DrawString(spriteFont, "MP", new Vector2(start.X + 100, start.Y + 50), Color.White);
                spritebatch.DrawString(spriteFont, "EXP", new Vector2(start.X + 100, start.Y + 70), Color.White);

                spritebatch.Draw(emptyBar, new Rectangle((int)start.X + 140, (int)start.Y + 35, 80, 10), Color.White);
                spritebatch.Draw(emptyBar, new Rectangle((int)start.X + 140, (int)start.Y + 55, 80, 10), Color.White);
                spritebatch.Draw(emptyBar, new Rectangle((int)start.X + 140, (int)start.Y + 75, 80, 10), Color.White);

                int curHP = GetBarFill(comb.HP, comb.MaxHP);
                int curMP = GetBarFill(comb.MP, comb.MaxMP);
                int curEXP = GetBarFill(18, 100);

                spritebatch.Draw(fullBar, new Rectangle((int)start.X + 140, (int)start.Y + 35, curHP, 10), Color.White);
                spritebatch.Draw(fullBar, new Rectangle((int)start.X + 140, (int)start.Y + 55, curMP, 10), Color.White);
                spritebatch.Draw(fullBar, new Rectangle((int)start.X + 140, (int)start.Y + 75, curEXP, 10), Color.White);

                spritebatch.DrawString(smallFont, comb.HP + "/" + comb.MaxHP, new Vector2(start.X + 223, start.Y + 32), Color.Red);
                spritebatch.DrawString(smallFont, comb.MP + "/" + comb.MaxMP, new Vector2(start.X + 223, start.Y + 52), Color.Red);
                spritebatch.DrawString(smallFont, "18/100", new Vector2(start.X + 223, start.Y + 72), Color.Red);
            }
        }

             public int GetBarFill(int current, int max)
        {
            float ratio = (float)current / (float)max;

            return ((int)(ratio * 80));
        }
        
    }
}
