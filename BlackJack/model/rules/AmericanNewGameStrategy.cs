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

            /*Card card4 = new Card(Card.Color.Clubs, Card.Value.Six);
            a_player.DealCard(card4);
            card4.Show(true);

            Card card3 = new Card(Card.Color.Clubs, Card.Value.Two);
            a_player.DealCard(card3);
            card3.Show(true);

            Card card = new Card(Card.Color.Clubs, Card.Value.Nine);
            a_dealer.DealCard(card);
            card.Show(true);

            Card card2 = new Card(Card.Color.Clubs, Card.Value.King);
            a_dealer.DealCard(card2);
            card.Show(true);*/

            return true;
        }

        public bool IsDealerWinner(Dealer a_dealer, Player a_player)
        {
            return a_dealer.CalcScore() >= a_player.CalcScore();
        }
    }
}
