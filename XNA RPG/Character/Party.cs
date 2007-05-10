using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace XNA_RPG.Character
{
    public class Party
    {
        #region Attributes
        private Hashtable combatants;
        private Inventory bag;
        public enum Status { Active, Inactive };
        #endregion

        #region Properties
        /// <summary>
        /// This property gets the Hashtable of all combatants.
        /// </summary>
        public Hashtable Combatants
        {
            get { return this.combatants; }
        }

        /// <summary>
        /// This property gets a List of the active members in the Party.
        /// </summary>
        public List<Combatant> ActiveMembers
        {
            get
            {
                List<Combatant> am = new List<Combatant>();
                foreach (Combatant comb in this.combatants.Keys)
                {
                    Status combStat = (Status)this.combatants[comb];
                    if (combStat == Status.Active)
                    {
                        am.Add(comb);
                    }
                }
                return am;
            }
        }

        /// <summary>
        /// This property gets a List of the inactive members in the Party.
        /// </summary>
        public List<Combatant> InactiveMembers
        {
            get
            {
                List<Combatant> im = new List<Combatant>();
                foreach (Combatant comb in this.combatants.Keys)
                {
                    Status combStat = (Status)this.combatants[comb];
                    if (combStat == Status.Inactive)
                    {
                        im.Add(comb);
                    }
                }
                return im;
            }
        }

        /// <summary>
        /// This property gets/sets the bag attribute.
        /// </summary>
        public Inventory Bag
        {
            get { return this.bag; }
            set { this.bag = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// This is the empty constructor for Party.
        /// </summary>
        public Party()
        {
            this.combatants = new Hashtable();
            this.bag = new Inventory();
        }
        #endregion

        #region Methods
        /// <summary>
        /// This method adds a combatant to the party.
        /// </summary>
        /// <param name="comb">The combatant to be added</param>
        /// <param name="stat">The status of the combatant</param>
        public void AddCombatant(Combatant comb, Status stat)
        {
            this.combatants.Add(comb, stat);
        }

        /// <summary>
        /// This method removes a combatant from the party.
        /// </summary>
        /// <param name="comb">The combatant to be removed</param>
        public void RemoveCombatant(Combatant comb)
        {
            this.combatants.Remove(comb);
        }
        #endregion
    }
}
