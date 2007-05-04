using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace XNA_RPG.Map
{
    public class Map
    {

        private Chipset chipset;
        private int width;
        private int height;

        private int[,] bottomLayer;
        private int[,] middleLayer;
        private int[,] topLayer;
        private ChipsetTile[,] objectLayer;


        private Vector2 focus;

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
        }

        public int Height
        {
            get
            {
                return height;
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

        #endregion


        public Map(Chipset chipset, int width, int height)
        {
            this.chipset = chipset;
            this.width = width;
            this.height = height;

            bottomLayer = new int[width, height];
            middleLayer = new int[width, height];
            topLayer = new int[width, height];
            objectLayer = new ChipsetTile[width, height];


        }

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





    }
}
