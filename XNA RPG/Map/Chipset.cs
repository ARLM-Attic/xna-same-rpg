using System;
using System.Collections.Generic;
using System.Text;

namespace XNA_RPG.Map
{
    public class Chipset
    {
        private int width;
        private int height;
        private List<ChipsetTile> tiles;

        #region Accessors
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

        public List<ChipsetTile> Tiles
        {
            get
            {
                return tiles;
            }
            set
            {
                tiles = value;
            }
        }
        #endregion


        public Chipset(int width, int height)
        {
            tiles = new List<ChipsetTile>();
            this.width = width;
            this.height = height;
        }

        public void AddTile(string assetName, bool isWalkable)
        {
            tiles.Add(new ChipsetTile(assetName, tiles.Count, isWalkable));
            Console.WriteLine(tiles[0]);
        }

    }
}
