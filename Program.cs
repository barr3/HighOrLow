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
	    
	    
            symbol.Add("Hearts", "Hearts"); //"\u2665"n
	    symbol.Add("Clubs", "Clubs"); //"\u2666"
	    symbol.Add("Diamonds", "Diamonds"); //"\u2663"
            symbol.Add("Spades", "Spades"); //"\u2660"

            int points = 0;
            int thisCardValue = 0;
            int lastCardValue = 0; 
            bool higher = true;
	    for (int count = 0; count < 13; count++) 
            {


                thisCardValue = getCard();
		
		if (count > 0)
		{
                    points = evaluateCards(thisCardValue, lastCardValue, points, higher);
                }
		
                Console.WriteLine("Will next card be higher or lower? (h/l) \n");

		if (count > 0)
		{
		    Console.WriteLine("Points: " + points);
		}


                higher = getInput();

                lastCardValue = thisCardValue;

            }

        }

	static bool getInput()
	{
            while (true)
            {
		ConsoleKey guess = Console.ReadKey(true).Key;
		if (guess == ConsoleKey.L)
                {
                    return false;
                }
                else if (guess == ConsoleKey.H)
                {
                    return true;
                }
		else {
                    Console.WriteLine("Please press h or l");		    
                }

            }

        }


        static int evaluateCards(int thisCardValue, int lastCardValue, int points, bool higher)
        {
	    if (higher == true)
	    {
		if (thisCardValue > lastCardValue)
		{
                    Console.WriteLine("Points in method: " + points++);
                    return points++;   
		}
	    }

	    if (higher == false)
	    {
		if (thisCardValue < lastCardValue)
		{
                    Console.WriteLine("Points in method: " + points++);		    
		    return points++;   
		}
		    
	    }
	    Console.WriteLine("Points in method: " + points);		    	    
	    return points;

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
	    
            Console.WriteLine(rank + " of " + suit);
            deck.RemoveAt(cardNum);

            // return cardNum;
	    return rankInt;

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

