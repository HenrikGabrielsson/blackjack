using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy GetHitRule()
        {
            return new Soft17Strategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            return new AmericanNewGameStrategy();
        }

        public IWinnerStrategy GetWinnerRule()
        {
            //return new DealerWinnerStrategy();
           return new PlayerWinnerStrategy();
        }

    }
}
