﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : GetShowAndDeal, INewGameStrategy
    {
        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            getShowAndDealCard(a_deck, true, a_player);
            getShowAndDealCard(a_deck,true,a_dealer);
            getShowAndDealCard(a_deck, true, a_player);
            getShowAndDealCard(a_deck, false, a_dealer);
          
            return true;
        }
    }
}
