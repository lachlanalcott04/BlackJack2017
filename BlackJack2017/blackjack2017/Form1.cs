using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack2017
{
    public partial class Form1 : Form
    {

        int numberOfDecks = 8;
        int numPlayers = 4;

        String[] suits = new String[]{"Hearts", "Diamonds", "Clubs", "Spades" };
        int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };
        int[] faceValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        List<Card> deck = new List<Card>();
        List<Hand> players = new List<Hand>();

        public Form1()
        {
            InitializeComponent();

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            createCards();
            shuffle();
            createPlayers(numPlayers);
            dealCards(numPlayers);

            // temporary
            displayHands();
        }

        private void createPlayers(int playNumber)
        {
            for(int i = 0; i< playNumber; i++)
            {
                Hand newHand = new Hand();
                players.Add(newHand);
            }
        }

        private void dealCards(int playerCount)
        {
            for(int i = 0; i < 2; i++)
            {

                foreach(Hand h in players)
                {
                    h.addCardToHand(deck[0]);
                    deck.RemoveAt(0);
                }

            }
        }

        public void displayHands()
        {
            foreach(Hand h in players)
            {
                textBox1.Text += h.getValue().ToString() + " | ";
            }
        }

        public void shuffle()
        {
            Random rand = new Random();

            for(int i = 0; i < 1000; i++)
            {
                Card tempCard = new Card();
                int card1 = rand.Next(deck.Count);
                int card2 = rand.Next(deck.Count);
                tempCard = deck[card1];
                deck[card1] = deck[card2];
                deck[card2] = tempCard;
            }
        }

        public void createCards()
        {
            for (int i = 0; i < numberOfDecks; i++)
            {
                foreach(String suit in suits)
                {
                    for(int val = 0; val<13; val++)
                    {
                        Card card = new Card();
                        card.suit = suit;
                        card.value = values[val];
                        card.faceValue = faceValues[val];
                        if(val == 0)
                        {
                            card.isAce = true;
                        }
                        deck.Add(card);
                    }
                }
            }
        }

        private void player_Click(object sender, EventArgs e)
        {

        }
    }
}
