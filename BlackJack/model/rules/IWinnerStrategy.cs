using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IWinnerStrategy
    {
        bool IsDealerWinner(Dealer a_dealer, Player a_player);

        int GetMaxScore();
    }
}
