using System;
using System.Collections.Generic;
using Bet.Domain.SeedWork;

namespace Bet.Domain.Bet
{
    public class Bet : Entity
    {
        /// <summary>
        /// Date when the bet has been created
        /// </summary>
        private DateTime Date { get; set; }

        /// <summary>
        /// Determine with the amount put on the bet, what the return will be
        /// </summary>
        private double Odds { get; set; }

        /// <summary>
        /// Amount of money put on the bet
        /// </summary>
        private double Stake { get; set; }

        /// <summary>
        /// Different bet item composing the bet
        /// </summary>
        public List<BetItem> Items { get; set; }

        public BetState State
        {
            get
            {
                var state = (BetState)0;
                foreach (var bet in Items)
                {
                    if (bet.State == BetState.Lost)
                        return BetState.Lost;

                    if (bet.State > state)
                        state = bet.State;
                }

                return state;
            }
        }
    }
}
