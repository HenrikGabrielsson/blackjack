using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : model.IGetHandListener
    {
        private view.IView m_view;
        private model.Game m_game;

        public PlayGame(view.IView a_view, model.Game a_game) {
            m_view = a_view;
            m_game = a_game;
        }

        public bool Play()
        {
            CallView();

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }

            switch (m_view.GetInput())
            {
                case BlackJack.view.Event.StartNewRound:
                    m_game.NewGame();
                    break;
                case BlackJack.view.Event.Hit:
                    m_game.Hit();
                    break;
                case BlackJack.view.Event.Stand:
                    m_game.Stand();
                    break;
                case BlackJack.view.Event.Quit:
                    return false;
            }

            return true;
        }

        public void Notify()
        {
            Thread.Sleep(1000);
            CallView();
        }

        private void CallView()
        {
            m_view.DisplayWelcomeMessage();

            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
        }
    }
}
