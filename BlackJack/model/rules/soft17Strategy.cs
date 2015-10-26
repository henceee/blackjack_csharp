﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    /*
     * The new variant is “Soft 17″, use the same design pattern already present for Hit.
     * Soft 17 means that the dealer has 17 but in a combination of Ace and 6 (for example Ace, two, two, two).
     * This means that the Dealern can get another card valued at 10 but still have 17 as the value of the ace 
     * is reduced to 1. Using the soft 17 rule the dealer should take another card 
     * (compared to the original rule when the dealer only takes cards on a score of 16 or lower).
     * 
     * ¨/https://coursepress.lnu.se/kurs/objektorienterad-analys-och-design-med-uml/workshops-2/workshop-3-design-using-patterns/)
     */
    class soft17Strategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(Player a_dealer)
        {
            int score = 0;
            bool hasAce = false;

            IEnumerable<Card> hand = a_dealer.GetHand();

            //if the dealear has 17...            
            if (a_dealer.CalcScore() == g_hitLimit)
            {
                foreach (Card c in hand)
                {
                    c.Show(true);
                    //And one of the cards is an ace (normally valued 11)    
                    if (c.GetValue() == Card.Value.Ace)
                    {
                        hasAce = true;
                        break;
                    }
                }

            }                               
            //if hasAce is true,Ace is now valued 1     -otherwise normal value
            score = (hasAce) ? a_dealer.CalcScore() - 10 : a_dealer.CalcScore();
            return score < g_hitLimit;
        }        
    }

}
