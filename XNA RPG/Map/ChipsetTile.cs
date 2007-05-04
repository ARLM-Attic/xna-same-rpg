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
    public class ChipsetTile
    {
        public const int WIDTH = 64;
        public const int HEIGHT = 64;
        private string assetName;
        private int chipsetIndex;
        private Texture2D texture;
        private bool isWalkable;

        #region Accessors
        
        public string AssetName
        {
            get
            {
                return assetName;
            }
            set
            {
                assetName = value;
            }
        }

        public int ChipsetIndex
        {
            get
            {
                return chipsetIndex;
            }
            set
            {
                chipsetIndex = value;
            }
        }

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

        public bool IsWalkable
        {
            get
            {
                return isWalkable;
            }
            set
            {
                isWalkable = value;
            }
        }
        #endregion


        public ChipsetTile(string assetName, int chipsetIndex, bool isWalkable)
        {
            this.assetName = assetName;
            this.chipsetIndex = chipsetIndex;
            this.isWalkable = isWalkable;
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return ("Tile picture: " + assetName +
                "chipset index: " + chipsetIndex);
        }

        
    }
}
