using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RPGLibrary
{
    public class Item
    {
        #region Attributes
        private string name;
        #endregion

        #region Properties
        /// <summary>This method gets/sets the name attribute.</summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// This is the empty constructor for Item.
        /// </summary>
        public Item()
        {
        }

        /// <summary>
        /// This constructor takes in a string as the name of the item.
        /// </summary>
        /// <param name="n">the name of the item</param>
        public Item(string n)
        {
            this.name = n;
        }
        #endregion

        #region Methods
        /// <summary>This method returns the name of the Item.</summary>
        public override string ToString()
        {
            return this.Name;
        }
        #endregion
    }
}

