using System;
using System.Collections.Generic;

namespace HighOrLow
{

    public class Score
    {
        public string player;
        public int score;

        public static List<Score> highScores = new List<Score>();
	
	
        public Score(string player, int score)
        {
            this.player = player;
            this.score = score;
            highScores.Add(this);
            writeScore(this);
        }

        public Score() { }

	public static void writeScore(Score score) //Writes the score to an XML-file
	{

            System.Xml.Serialization.XmlSerializer writer =
		new System.Xml.Serialization.XmlSerializer(typeof(List<Score>));
            System.IO.FileStream file = System.IO.File.Create("./score.xml");

            writer.Serialize(file, highScores);
            file.Close();

        }

	
        public static void readScore()
        {
            System.Xml.Serialization.XmlSerializer reader =
		new System.Xml.Serialization.XmlSerializer(typeof(List<Score>));
            System.IO.StreamReader file = new System.IO.StreamReader("./score.xml");
            List<Score> scoreList = (List<Score>)reader.Deserialize(file);
            file.Close();

            highScores = scoreList;

        }

        public static void sortHighScores()
        {
            highScores.Sort(delegate (Score x, Score y)
                {
                    return y.score.CompareTo(x.score);		    
                });

        }

        public static void showHighScores()	    
        {
            sortHighScores();
            Console.Clear();
            Console.WriteLine("High scores");
            for (int i = 0; i < highScores.Count; ++i) {
                Console.WriteLine((i+1) + ": " + highScores[i].player + "\t|\t" + highScores[i].score);
            }
	}

        public string getPlayer()
        {
            return this.player;       
        }
        public int getScore()
        {
            return this.score;
        }

    }

}
