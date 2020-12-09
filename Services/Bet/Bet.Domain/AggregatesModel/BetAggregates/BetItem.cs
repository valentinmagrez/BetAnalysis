using System;
using Bet.Domain.Bet;
using Bet.Domain.SeedWork;

namespace Bet.Domain.BetAggregates
{
    public class BetItem : Entity
    {
        /// <summary>
        /// Date when the even take place
        /// </summary>
        private DateTime EventDate { get; set; }

        /// <summary>
        /// Description name of the event
        /// Ex: Paris SG - Bayern Munich
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Description name of the type of bet
        /// Ex: Vainqueur du match
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// On what user bet
        /// Ex: Paris SG
        /// </summary>
        public string Selection { get; set; }

        /// <summary>
        /// Sport category of the bet
        /// </summary>
        public string Sport { get; set; }

        /// <summary>
        /// Current bet state 
        /// </summary>
        public BetState State { get; set; }

        /// <summary>
        /// Value use by external bet provider
        /// </summary>
        public string ExternalIdentifier { get; set; }
    }
}