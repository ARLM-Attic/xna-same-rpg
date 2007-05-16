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
        private enum ChoiceState { Use, UseReady, UseChar, UseCharReady, ApplyItem, ApplyItemReady, Sort, SortReady, Discard, DiscardReady, Home, HomeReady };
        private Texture2D background;
        private Texture2D hand;
        private Texture2D emptyBar;
        private Texture2D fullBar;
        private SpriteFont spriteFont;
        private SpriteFont smallFont;
        private int handIndex;
        private int itemIndex;
        private ChoiceState state;
        private List<string> inventory;
        private Keys waitingKey;
        private Vector2 lastValidHand;
        private bool first;

        public Items(string title, ContentManager content)
            : base(title, content)
        {
            background = content.Load<Texture2D>("Content\\Menu\\ItemsBackground");
            hand = content.Load<Texture2D>("Content\\Menu\\menuHand");
            emptyBar = content.Load<Texture2D>("Content\\Menu\\EmptyBar");
            fullBar = content.Load<Texture2D>("Content\\Menu\\FullBar");
            spriteFont = content.Load<SpriteFont>("Content\\Fonts\\Arial13");
            smallFont = content.Load<SpriteFont>("Content\\Fonts\\Arial9");
            handIndex = 0;
            state = ChoiceState.Home;
            itemIndex = 0;

            first = true;
            waitingKey = Keys.Left;
        }

        public override void Draw(SpriteBatch spritebatch, Party party, SpriteFont spriteFont)
        {

            inventory = GetItems(party);

            spritebatch.Draw(background, new Rectangle(20, 0, 600, 600), Color.White);

            spritebatch.DrawString(spriteFont, "Use", new Vector2(180, 20), Color.White);
            spritebatch.DrawString(spriteFont, "Sort", new Vector2(280, 20), Color.White);
            spritebatch.DrawString(spriteFont, "Discard", new Vector2(380, 20), Color.White);

            lastValidHand = GetHandPosition();

            spritebatch.Draw(hand, new Rectangle((int)lastValidHand.X, (int)lastValidHand.Y, 60, 40), Color.White);


            for (int i = 0; i < inventory.Count; i++)
            {

                spritebatch.DrawString(spriteFont, inventory[i], new Vector2(380, i * 25 + 100), Color.White);

            }

            DrawCharacters(spritebatch, party);

            spritebatch.Draw(hand, new Rectangle((int)lastValidHand.X, (int)lastValidHand.Y, 60, 40), Color.White);

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

        public override bool UpdateSubMenu(KeyboardState keyboard, Party party)
        {

            if (first == true)
            {

                if (keyboard.IsKeyUp(Keys.F))
                {
                    first = false;
                }

                return true;
            }


            switch (state)
            {
                case ChoiceState.Home:

                    if (keyboard.IsKeyDown(Keys.Left))
                    {
                        state = ChoiceState.HomeReady;
                        waitingKey = Keys.Left;
                    }

                    else if (keyboard.IsKeyDown(Keys.Right))
                    {
                        state = ChoiceState.HomeReady;
                        waitingKey = Keys.Right;
                    }

                    else if (keyboard.IsKeyDown(Keys.Back))
                    {
                        first = true;
                        return false;
                    }

                    else if (keyboard.IsKeyDown(Keys.F))
                    {
                        if (handIndex == 0)
                        {
                            state = ChoiceState.UseReady;
                            waitingKey = Keys.F;
                        }
                        else if (handIndex == 1)
                        {
                            state = ChoiceState.SortReady;
                            waitingKey = Keys.F;
                        }
                        else if (handIndex == 2)
                        {
                            state = ChoiceState.DiscardReady;
                            waitingKey = Keys.F;
                        }

                        handIndex = 0;
                    }

                    return true;

                case ChoiceState.HomeReady:

                    if (keyboard.IsKeyUp(Keys.Left) && waitingKey == Keys.Left
                        && handIndex > 0)
                    {
                        handIndex--;
                        state = ChoiceState.Home;
                    }
                    else if (keyboard.IsKeyUp(Keys.Right) && waitingKey == Keys.Right
                        && handIndex < 2)
                    {
                        handIndex++;
                        state = ChoiceState.Home;
                    }
                    else if (keyboard.IsKeyUp(Keys.Back) && waitingKey == Keys.Back)
                    {
                        state = ChoiceState.Home;
                        handIndex = 0;
                    }

                    return true;

                case ChoiceState.UseReady:

                    if (keyboard.IsKeyUp(Keys.F) && waitingKey == Keys.F)
                    {
                        state = ChoiceState.Use;

                    }

                    else if (keyboard.IsKeyUp(Keys.Down) && waitingKey == Keys.Down)
                    {
                        handIndex++;
                        state = ChoiceState.Use;

                    }

                    else if (keyboard.IsKeyUp(Keys.Up) && waitingKey == Keys.Up)
                    {
                        handIndex--;
                        state = ChoiceState.Use;

                    }

                    else if (keyboard.IsKeyUp(Keys.Back) && waitingKey == Keys.Back)
                    {
                        state = ChoiceState.Use;
                        handIndex = itemIndex;
                    }

                    return true;

                case ChoiceState.Use:

                    if (keyboard.IsKeyDown(Keys.Back))
                    {
                        state = ChoiceState.HomeReady;
                        waitingKey = Keys.Back;
                    }

                    else if (keyboard.IsKeyDown(Keys.Down) && handIndex < inventory.Count - 1)
                    {
                        state = ChoiceState.UseReady;
                        waitingKey = Keys.Down;
                    }

                    else if (keyboard.IsKeyDown(Keys.Up) && handIndex > 0)
                    {
                        state = ChoiceState.UseReady;
                        waitingKey = Keys.Up;
                    }

                    else if (keyboard.IsKeyDown(Keys.F))
                    {
                        state = ChoiceState.UseCharReady;
                        waitingKey = Keys.F;
                        itemIndex = handIndex;
                        handIndex = 0;
                    }
                    return true;

                case ChoiceState.UseCharReady:

                    if (keyboard.IsKeyUp(Keys.F) && waitingKey == Keys.F)
                    {
                        state = ChoiceState.UseChar;
                    }

                    else if (keyboard.IsKeyUp(Keys.Down) && waitingKey == Keys.Down)
                    {
                        state = ChoiceState.UseChar;
                        handIndex++;
                    }

                    else if (keyboard.IsKeyUp(Keys.Up) && waitingKey == Keys.Up)
                    {
                        state = ChoiceState.UseChar;
                        handIndex--;
                    }

                    return true;

                case ChoiceState.UseChar:

                    if (keyboard.IsKeyDown(Keys.F))
                    {
                        waitingKey = Keys.F;
                        state = ChoiceState.ApplyItemReady;
                    }

                    else if (keyboard.IsKeyDown(Keys.Up) && handIndex > 0)
                    {
                        state = ChoiceState.UseCharReady;
                        waitingKey = Keys.Up;
                    }

                    else if (keyboard.IsKeyDown(Keys.Down) && handIndex < party.ActiveMembers.Count - 1)
                    {
                        state = ChoiceState.UseCharReady;
                        waitingKey = Keys.Down;
                    }

                    else if (keyboard.IsKeyDown(Keys.Back))
                    {
                        state = ChoiceState.UseReady;
                        waitingKey = Keys.Back;
                    }

                    return true;

                case ChoiceState.ApplyItemReady:

                    if (keyboard.IsKeyUp(Keys.F) && waitingKey == Keys.F)
                    {
                        state = ChoiceState.ApplyItem;
                    }

                    return true;

                case ChoiceState.ApplyItem:

                    //still need to change items around, can't use item right now
                    state = ChoiceState.Use;
                    handIndex = itemIndex;
                    //Also, need to remove item after use, and determine if index is still ok.

                    return true;

                default:
                    return true;
            }

        }

        public Vector2 GetHandPosition()
        {


            switch (state)
            {
                case ChoiceState.Home:
                    return new Vector2(handIndex * 100 + 120, 20);

                case ChoiceState.Use:
                    return new Vector2(318, handIndex * 25 + 100);
                
                case ChoiceState.UseChar:
                    return new Vector2(10, handIndex * 150 + 150);

                default:
                    return lastValidHand;
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
