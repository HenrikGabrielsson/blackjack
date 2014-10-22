using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame
    {
        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            switch (a_view.GetInput())
            {
                case BlackJack.view.Event.StartNewRound:
                    a_game.NewGame();
                    break;
                case BlackJack.view.Event.Hit:
                    a_game.Hit();
                    break;
                case BlackJack.view.Event.Stand:
                    a_game.Stand();
                    break;
                case BlackJack.view.Event.Quit:
                    return false;
            }

            return true;
        }
    }
}
