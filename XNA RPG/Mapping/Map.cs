using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using XNA_RPG.Events;

namespace XNA_RPG.Mapping
{
    public class Map
    {

        private Chipset chipset;
        private int width;
        private int height;
        private string name;

        private int[,] bottomLayer;
        private int[,] middleLayer;
        private int[,] topLayer;
        private ChipsetTile[,] objectLayer;
        private Event[,] eventLayer;

        private Vector2 focus;

        private Texture2D battleBackground;

        #region Accessors

        public Chipset Chipset
        {
            get
            {
                return chipset;
            }
            set
            {
                chipset = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public int[,] BottomLayer
        {
            get
            {
                return bottomLayer;
            }
        }

        public int[,] MiddleLayer
        {
            get
            {
                return middleLayer;
            }
        }

        public int[,] TopLayer
        {
            get
            {
                return topLayer;
            }
        }

        public ChipsetTile[,] ObjectLayer
        {
            get
            {
                return objectLayer;
            }
        }

        public Vector2 Focus
        {
            get
            {
                return focus;
            }
            set
            {
                focus = value;
            }
        }

        public Texture2D BattleBackground
        {
            get
            {
                return battleBackground;
            }
            set
            {
                battleBackground = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                name = value;
            }
        }
        #endregion

        #region Constructors
        public Map()
        {
            this.chipset = null;
            this.bottomLayer = new int[0, 0];
            this.middleLayer = new int[0, 0];
            this.topLayer = new int[0, 0];
            this.objectLayer = new ChipsetTile[0, 0];
            this.eventLayer = new Event[0, 0];
            this.name = "?";
        }

        public Map(Chipset chipset, int width, int height, string name)
        {
            this.chipset = chipset;
            this.width = width;
            this.height = height;
            this.name = name;

            bottomLayer = new int[width, height];
            middleLayer = new int[width, height];
            topLayer = new int[width, height];
            objectLayer = new ChipsetTile[width, height];
            eventLayer = new Event[width, height];
        }
        #endregion

        public void InsertIntoBottomLayer(int[] chipsetIndices)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    bottomLayer[i,j] = chipsetIndices[j * height + i];
                }
            }
        }

        public void OnTouchEvent(Vector2 tilePosition)
        {
            if (eventLayer[(int)tilePosition.X, (int)tilePosition.Y] != null
                && eventLayer[(int)tilePosition.X, (int)tilePosition.Y].GetType().FullName == "Events.OnTouchEvent")

            {
                eventLayer[(int)tilePosition.X, (int)tilePosition.Y].Trigger();
            }
        }
    }
}
