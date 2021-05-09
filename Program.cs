using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;


namespace HighOrLow
{
    class Program
    {
	static List<Card> deck = new List<Card>();
	static Dictionary<string, string> symbol = new Dictionary<string, string>();
	static Dictionary<string, string> letter = new Dictionary<string, string>();


        static void Main(string[] args)
        {

	    //Prepares the console
	    Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Clear();	    
            Score.readScore(); //Reads the scores from the score.xml file

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose menu option");

                while (true)
                {
                    try
                    {
                        Console.WriteLine("1. Play game");
                        Console.WriteLine("2. Show high scores.");
                        Console.WriteLine("3. Exit game.");

                        int menuOption = int.Parse(Console.ReadLine());

                        switch (menuOption)
                        {
                            case 1:
                                play();
                                break;
                            case 2:
                                Score.showHighScores();
                                break;
                            case 3:
				System.Environment.Exit(0);  
                                break;
                            default:
                                play();
                                break;
                        }
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Please choose a menu option.");
                    }

                }

            }
        }

        static void play()
        {
            createDeck(); 

            symbol.Add("Hearts", "Hearts"); //"\u2665"n
            symbol.Add("Clubs", "Clubs"); //"\u2666"
            symbol.Add("Diamonds", "Diamonds"); //"\u2663"
            symbol.Add("Spades", "Spades"); //"\u2660"

            int totalPoints = 0;
            for (int i = 0; i < 4; ++i)
            {
                int roundPoints = playRound();
                if (roundPoints < 0) {
                    break;
                }
                totalPoints += roundPoints;
                Console.Clear();		
            }

	    Console.WriteLine("Total points: " + totalPoints + "\n");		    

            Console.Write("Please enter player name: ");
            string playerName = Console.ReadLine();

            Score score = new Score(playerName, totalPoints);

	}


        static int playRound()
        {
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
		    if (points < 0)
		    {
                        Console.WriteLine("You got at pair. You lose.");
                        Console.WriteLine("Press enter to continue...");
			Console.ReadLine();
			return -100;
                    }
                }

                Console.WriteLine("Will next card be higher or lower? (h/l) \n");

                if (count > 0)
                {
                    Console.WriteLine("Points: " + points + "\n");
                }

		
                higher = getInput();

                lastCardValue = thisCardValue;

            }
            Console.WriteLine("Total points this round: " + points + "\n");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();

	    if (points == 13)
	    {
                points += 50;
            }	  
            return points;

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
	    if (thisCardValue == 0)
	    {
                points++;
            }
	    else if (thisCardValue == lastCardValue)
	    {
		return -100;
	    }
	    
	    else if (higher == true)
	    {
		if (thisCardValue > lastCardValue)
		{
                    points++;
		}
	    }
	    else if (higher == false)
	    {
		if (thisCardValue < lastCardValue)
		{
                    points++;
                }
		    
	    }

	    
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
	//     Clubs,p
	//     Diamonds,
	//     Spades
        // }


        static void createDeck()
        {
            deck.Clear();
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

