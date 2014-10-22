using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17Strategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            IEnumerable<Card> hand = a_dealer.GetHand();

            if (hand.Any(item => item.GetValue() == Card.Value.Ace) && a_dealer.CalcScore() == g_hitLimit) {
                return true;
            }

            return a_dealer.CalcScore() < g_hitLimit;
        }
    }
}
