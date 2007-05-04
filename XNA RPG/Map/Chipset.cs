using System;
using System.Collections.Generic;
using System.Text;

namespace XNA_RPG.Map
{
    public class Chipset
    {
        private int width;
        private int height;
        private List<Tile> tiles;

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

        public List<Tile> Tiles
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
            tiles = new List<Tile>();
            this.width = width;
            this.height = height;
        }

        public void AddTile(string assetName)
        {
            tiles.Add(new Tile(assetName, tiles.Count));
            Console.WriteLine(tiles[0]);
        }

    }
}
