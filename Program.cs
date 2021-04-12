using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace HighOrLow
{
    class Program
    {
        static void Main(string[] args)
        {

	    Console.OutputEncoding = System.Text.Encoding.Default;


	    

	    Console.WriteLine("Hello World!");

            // Value test = Value.king;
            // Console.WriteLine(test);

            var suit = RandomEnumValue<Suit>();
            var value = RandomEnumValue<Value> ();
	    
	    Console.WriteLine (value.ToString () +" of " + suit.ToString());


	    string a = "\u2660";  
	    Console.WriteLine(a);  


        }

	static Random _R = new Random ();
	static T RandomEnumValue<T> ()
	{
	    var v = Enum.GetValues (typeof (T));
	    return (T) v.GetValue (_R.Next(v.Length));
	}

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


        enum Suit {
	    Hearts,
	    Clubs,
	    Diamonds,
	    Spades
        }

        static void writeScore() {

	    string jsonString = "Hej";

	    File.WriteAllText("./test.txt", jsonString);
	    
	}

    }
}
