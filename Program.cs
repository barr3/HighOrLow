using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace HighOrLow
{
    class Program
    {
	static List<Card> deck = new List<Card>();
	static Dictionary<string, string> symbol = new Dictionary<string, string>();
	static Dictionary<string, string> letter = new Dictionary<string, string>();
	
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.Unicode; 

	    Random rnd = new Random();
	    
            createDeck();
	    
            symbol.Add("Hearts", "\u2665");
	    symbol.Add("Clubs", "\u2666");
	    symbol.Add("Diamonds", "\u2663");
            symbol.Add("Spades", "\u2660");


            int count = 0;
            // int lastCardValue;
            // bool higher;
            while (true)  //main program loop
            {
		if (count == 13) {
                    break;
                }

		int lastCardValue;
                var thisCardValue  = getCard();
                Console.WriteLine("Will next card be higher or lower?");
                string guess = Console.ReadLine().ToLower();


                if (guess == "h")
                {
                    Console.WriteLine("Higher");
                }
                else if (guess == "l")
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("burh");
                }



                lastCardValue = thisCardValue;


            }

        }

        // enum Value
        // {
	//     Ace,
	//     Two,
	//     Three,
	//     Four,
	//     Five,
	//     Six,
	//     Seven,
	//     Eight,
	//     Nine,
	//     Ten,
        //     Jack,
        //     Queen,
        //     King
        // }


        // enum Suit
	// {
	//     Hearts,
	//     Clubs,
	//     Diamonds,
	//     Spades
        // }

        static void writeScore()
	{

	    string jsonString = "Hej";

	    File.WriteAllText("./test.txt", jsonString);
	    
	}

        static void createDeck()
        {
	    //Lägg alla i samma loop sen
	    for (int i = 0; i < 13; ++i) {
                deck.Add(new Card(i, "Diamonds"));
		deck.Add(new Card(i, "Clubs"));
                deck.Add(new Card(i, "Spades" ));
                deck.Add(new Card(i, "Hearts"));
            }

	    
        }

        static int getCard()
        {
	    Random rnd = new Random();
            var cardNum = rnd.Next(0, deck.Count);
            var rankInt = deck[cardNum].getRank();
            var suit = symbol[deck[cardNum].getSuit().ToString()];
	    
            string rank = convertRankToFacevalue(rankInt);
	    
            Console.WriteLine(rank + suit);
            deck.RemoveAt(cardNum);

            return cardNum;

        }

        static string convertRankToFacevalue(int rank)
        {

            switch (rank)
	    {
		case 0:
                    return "A";
		case 10:
                    return "J";
		case 11:
                    return "Q";
		case 12:
                    return "K";
                default:
                    rank++;
                    return rank.ToString();
            }

        }
	
    }
}
