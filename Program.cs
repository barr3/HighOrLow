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


            // Value test = Value.king;
            // Console.WriteLine(test);



            // var suit = RandomEnumValue<Suit>();
            // var value = RandomEnumValue<Value>();

	    Random rnd = new Random();
	    
            string[] suits = new string[4];

            suits[0] = "Clubs";
            suits[1] = "Diamonds";
            suits[2] = "Hearts";
            suits[3] = "Spades";

            var suit = suits[rnd.Next(0, 3)];
	    



	    

	    


            int temp = rnd.Next(0, 10);
            // Console.WriteLine(temp);

            // Console.WriteLine((Value)temp-1);
            createDeck();
            // Console.WriteLine(deck[0].getRank());

            // Console.WriteLine(value);

            // Console.WriteLine (value.ToString () +" of " + suit.ToString());

	    
            symbol.Add("Hearts", "\u2665");
	    symbol.Add("Clubs", "\u2666");
	    symbol.Add("Diamonds", "\u2663");
            symbol.Add("Spades", "\u2660");

            // string a = "\u2660";  
            // Console.WriteLine(a);

            // Console.WriteLine(value. + symbol[suit.ToString()]);



            // for (int i = 0; i < deck.Count; ++i) {
            //     Console.WriteLine(deck[i].getRank() + symbol[deck[i].getSuit().ToString()]);
            // }

            while (true)
            {
                getCard();
                Console.ReadLine();
            }


            // Card test = new Card("test", "korv");

            // Console.WriteLine(test.getRank());

        }

	// static Random _R = new Random ();
	// static T RandomEnumValue<T> ()
	// {
	//     var v = Enum.GetValues (typeof (T));
	//     return (T) v.GetValue (_R.Next(v.Length));
	// }

        enum Value
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


        enum Suit
	{
	    Hearts,
	    Clubs,
	    Diamonds,
	    Spades
        }

        static void writeScore()
	{

	    string jsonString = "Hej";

	    File.WriteAllText("./test.txt", jsonString);
	    
	}

        static void createDeck()
        {

	    for (int i = 0; i < 13; ++i) {
                deck.Add(new Card(i.ToString(), "Diamonds"));
            }

	    for (int i = 0; i < 13; ++i) {
                deck.Add(new Card(i.ToString(), "Clubs"));
            }	    

	    for (int i = 0; i < 13; ++i) {
                deck.Add(new Card(i.ToString(), "Spades" ));
            }	    

	    for (int i = 0; i < 13; ++i) {
                deck.Add(new Card(i.ToString(), "Hearts"));
            }

	    
        }

        static void getCard()
        {
	    Random rnd = new Random();
            var cardNum = rnd.Next(0, deck.Count);
	    Console.Write(deck[cardNum].getRank() + symbol[deck[cardNum].getSuit().ToString()] );
            deck.RemoveAt(cardNum);

        }


    }
}
