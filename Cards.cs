using System;

namespace HighOrLow
{

    class Card
    {

        private int rank;
        private string suit;

        public Card(int rank, string suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        public void setRank(int rank)
	{
            this.rank = rank;
        }

        public int getRank()
        {
            return rank;
        }

	public void setSuit(string suit)
	{
            this.suit = suit;
        }

        public string getSuit()
        {
            return suit;
        }
	
    }

}
