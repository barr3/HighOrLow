using System;

namespace HighOrLow
{

    class Card
    {

        private Value rank;
        private Suit suit;

        public Card(Value rank, Suit suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        // public void setRank(Value rank)
	// {
        //     this.rank = rank;
        // }

        public Value getRank()
        {
            return rank;
        }

	// public void setSuit(string suit)
	// {
        //     this.suit = suit;
        // }

        public Suit getSuit()
        {
            return suit;
        }

	public enum Value
        {
	    Ace,
	    Two,
	    Three,
	    Four,
	    Five,
	    Six,
	    Seven,
	    Eight,
	    Nine,
	    Ten,
            Jack,
            Queen,
            King
        }


        public enum Suit
	{
	    Hearts,
	    Clubs,
	    Diamonds,
	    Spades
        }

	
    }

}
