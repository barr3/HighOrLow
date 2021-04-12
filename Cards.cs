using System;

namespace HighOrLow
{

    class Card
    {

        private string rank {get; set; }
        private string suit {get; set; }

        public Card(string rank, string suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        public void setRank(string rank)
	{
            this.rank = rank;
        }

        public string getRank()
        {
            return rank;
        }

	public void setSuit(string rank)
	{
            this.suit = suit;
        }

        public string getSuit()
        {
            return suit;
        }
	
    }

}
