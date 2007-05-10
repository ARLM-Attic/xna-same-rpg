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
        public Items(string title)
            : base(title)
        {


        }

        public override void Draw(SpriteBatch spritebatch, Party party, SpriteFont spriteFont)
        {

            List<string> inventory = GetItems(party);

            foreach (DictionaryEntry item in party.Bag.Items)
            {
                inventory.Add((string)item.Key);
            }

            for(int i = 0; i < inventory.Count; i++)
            {

                spritebatch.DrawString(spriteFont, inventory[i], new Vector2(100, i * 20 + 60), Color.White);

            }

            
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
            if (keyboard.IsKeyDown(Keys.Back))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
