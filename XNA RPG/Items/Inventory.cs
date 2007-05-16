using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace XNA_RPG.Items
{
    public class Inventory
    {
        #region Attributes
        private Hashtable items;
        #endregion

        #region Properties
        public Hashtable Items
        {
            get { return this.items; }
            set { this.items = value; }
        }
        #endregion

        #region Constructors
        public Inventory()
        {
            this.items = new Hashtable();
        }
        #endregion

        #region Methods
        public bool HasItem(string n)
        {
            bool result = false;
            foreach (Item itm in this.items.Keys)
            {
                if (itm.Name == n)
                {
                    result = true;
                }
            }
            return result;
        }
        #endregion
    }
}
