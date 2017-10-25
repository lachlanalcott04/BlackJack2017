using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack2017
{
    public class Hand
    {
        List<Card> listOfCards = new List<Card>();

        public int getValue()
        {
            int handValue = 0;

            foreach(Card card in listOfCards)
            {
                handValue += card.value;
            }

            return handValue;
        }

        public void addCardToHand(Card newCard)
        {
            listOfCards.Add(newCard);
        }

        public void newHand()
        {
            listOfCards.Clear();
        }
    }
}
