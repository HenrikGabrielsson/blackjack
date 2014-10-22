using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Dealer a_dealer, Player a_player)
        {
            a_dealer.GiveCards(a_dealer, true);
            a_dealer.GiveCards(a_player, true);
            a_dealer.GiveCards(a_dealer);
            a_dealer.GiveCards(a_player, true);

            return true;
        }

        public bool IsDealerWinner(Dealer a_dealer, Player a_player)
        {
            return a_dealer.CalcScore() >= a_player.CalcScore();
        }
    }
}
