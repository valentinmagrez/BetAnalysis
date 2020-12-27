using System.Linq;
using Bet.Domain.Bet;
using Bet.Domain.BetAggregates;
using NFluent;
using NUnit.Framework;

namespace Bet.Domain.UnitTest
{
    public class StateTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new[] {BetState.Lost}, BetState.Lost)]
        [TestCase(new[] {BetState.Lost, BetState.Won, BetState.Won}, BetState.Lost)]
        [TestCase(new[] {BetState.Won, BetState.Won , BetState.Lost}, BetState.Lost)]
        [TestCase(new[] {BetState.Closed, BetState.Lost}, BetState.Lost)]
        [TestCase(new[] {BetState.InProgress, BetState.Lost}, BetState.Lost)]
        public void LostBetIsHighPriority(BetState[] states, BetState expected)
        {
            var bets = BuildBetItems(states);

            Check.That(bets.State).IsEqualTo(expected);
        }

        [TestCase(new[] {BetState.InProgress}, BetState.InProgress)]
        [TestCase(new[] {BetState.InProgress, BetState.Won, BetState.Won}, BetState.InProgress)]
        [TestCase(new[] {BetState.Won, BetState.Won , BetState.InProgress}, BetState.InProgress)]
        [TestCase(new[] {BetState.Closed, BetState.InProgress}, BetState.InProgress)]
        public void InprogressBetIsSecondPriority(BetState[] states, BetState expected)
        {
            var bets = BuildBetItems(states);

            Check.That(bets.State).IsEqualTo(expected);
        }

        [TestCase(new[] {BetState.Won}, BetState.Won)]
        [TestCase(new[] {BetState.Closed, BetState.Won}, BetState.Won)]
        public void WonBetIsThirdPriority(BetState[] states, BetState expected)
        {
            var bets = BuildBetItems(states);

            Check.That(bets.State).IsEqualTo(expected);
        }

        [TestCase(new[] {BetState.Closed }, BetState.Closed)]
        public void ClosedBetIsLowestPriority(BetState[] states, BetState expected)
        {
            var bets = BuildBetItems(states);

            Check.That(bets.State).IsEqualTo(expected);
        }

        private static AggregatesModel.BetAggregates.Bet BuildBetItems(BetState[] states)
        {
            var items = states.Select(_ => new BetItem {State = _});
            var bets = new AggregatesModel.BetAggregates.Bet {Items = items.ToList()};
            return bets;
        }
    }
}