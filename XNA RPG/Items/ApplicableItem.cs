using System;
using System.Collections.Generic;
using System.Text;
using XNA_RPG.Character;

namespace XNA_RPG.Items
{
    public class ApplicableItem : Item
    {
        #region Attributes
        private Application usability;
        public enum Application { Any, BattleOnly, FieldOnly }
        #endregion

        #region Properties
        /// <summary>
        /// This property gets/sets the usability attribute.
        /// </summary>
        public Application Usability
        {
            get { return this.usability; }
            set { this.usability = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// This is the empty constructor for ApplicableItem.
        /// </summary>
        public ApplicableItem()
            : base()
        {
            this.usability = Application.Any;
        }

        /// <summary>
        /// This is the preferred constructor for AppliacableItem.
        /// </summary>
        /// <param name="n">the name of the item</param>
        /// <param name="app">the usability of the item</param>
        public ApplicableItem(string n, Application app)
            : base(n)
        {
            this.usability = app;
        }
        #endregion

        #region Methods
        public virtual void Use(Combatant comb)
        {
        }
        #endregion
    }
}
