using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private int m_maxScore;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinnerStrategy m_winnerRule;


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winnerRule = a_rulesFactory.GetWinnerRule();
            m_maxScore = m_winnerRule.GetMaxScore();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver(a_player))
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(this, a_player);   
            }
            return false;
        }

        public bool Stand(Player a_player)
        {
            if (m_deck != null)
            {
                this.ShowHand();

                while (m_hitRule.DoHit(this) && !IsDealerWinner(a_player))
                {
                    Hit(this);
                }

            }
            return true;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && !IsGameOver(a_player))
            {
                GiveCards(a_player, true);

                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winnerRule.IsDealerWinner(this, a_player);
        }

        public bool IsGameOver(Player a_player)
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true || IsDealerWinner(a_player))
            {
                return true;
            }
            return false;
        }

        public void GiveCards(Player a_player, bool show = false)
        {
            Card card;

            card = m_deck.GetCard();
            card.Show(show);
            a_player.DealCard(card);
        }


    }
}
