using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1Problem5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarera och initiera antal gissningar
            int numberOfGuesses = 6;

            //Säg till den som ska spela att kolla bort sen skriv in ett ord
            Console.WriteLine("Den som ska spela måste titta bort nu!");
            Console.WriteLine("Skriv in ett ord: ");
            //Allt som skrivs in görs om till versaler
            string correctWord = Console.ReadLine().ToUpper();


            //Rensa skärmen
            Console.Clear();

            //skapa en char array som e lika lång som korrekta ordet
            char[] underscores = new char[correctWord.Length];
            //Skapa en lista som sparar in alla felaktiga bokstäver
            List<char> wrongLetters = new List<char>();

            //Starta for-loopen som går så länge det finns understräck i ordet
            for (int i = 0; i < underscores.Length; i++)
            {
                underscores[i] = '_';
            }

            //Starta while-loopen som går så länge ordet innehåller understräck och antalet av gissningar är över 0.
            while (underscores.Contains('_') && numberOfGuesses > 0)
            {
                //Sätt correctLetter till false
                bool correctLetter = false;
                //skriv ut understräcken + mellanslagen
                WriteCharArray(underscores);
                //Gör en if-loop som skriver ut alla felaktiga gissningar
                if (wrongLetters.Any())
                {
                    Console.WriteLine($"\nMissar: {string.Join(" ", wrongLetters)}");

                }

                Console.Write("\nGissa en bokstav eller ordet: ");
                //gör en string för gissningarna och gör dom till versaler
                string guessTemp = Console.ReadLine().ToUpper();
                //Gör en char för gissningarna
                char guess = guessTemp[0];
                //Gör in if-sats som kollar ifall spelaren försöker på att skriva hela ordet dvs mer än 1 bokstav
                //som både ger svar på ifall man skrivit in fel eller rätt.
                if (guessTemp.Length > 1)
                {
                    if (guessTemp == correctWord)
                    {
                        Console.WriteLine("Rätt ord!");
                        for (int i = 0; i < underscores.Length; i++)
                        {
                            underscores[i] = correctWord[i];
                        }

                    }
                    else
                    {
                        numberOfGuesses--;
                        Console.WriteLine("Fel ord! Du har: " + numberOfGuesses + " gissningar kvar!");
                        continue;
                    }
                }
                else
                {
                    //Om bokstaven redan finns i listan över fel bokstäver meddela det till spelaren
                    if (wrongLetters.Contains(guess) || underscores.Contains(guess))
                    {
                        Console.WriteLine("Du har redan gissat på bokstaven: " + guess);
                        continue;
                    }
                    //Skapa en for-loop som innehåller if-satser som kollar efter rätta bokstäver eller felaktiga
                    for (int i = 0; i < correctWord.Length; i++)
                    {
                        //Ifall gissningen stämmer överens med en bokstav i det hemliga ordet spara det
                        if (correctWord[i] == guess)
                        {
                            underscores[i] = correctWord[i];
                            correctLetter = true;
                        }
                    }
                    //Ifall det var rätt bokstav meddela det till spelaren och informera om hur många gissningar 
                    if (correctLetter)
                    {

                        Console.WriteLine("Rätt! Du har: " + numberOfGuesses + " kvar!");
                    }
                    else
                    //Annars informera om att det inte var rätt och ta bort en gissning ur antalet gissningar
                    {
                        wrongLetters.Add(guess);
                        numberOfGuesses--;
                        Console.WriteLine("Feeel! Du har: " + numberOfGuesses + " kvar!");

                    }
                }
            }
            //Skriv ut mellan slag mellan charsen i arrayn
            WriteCharArray(underscores);
            
            //ifall alla understräcken har bytts ut till bokstäver har man vunnit
            if (!underscores.Contains('_'))
            {
                Console.WriteLine("Du har vunnit spelet! Grattis!");
            }
            //Annars så har man förlorat
            else
            {
                Console.WriteLine("Du har torskat!");
            }
            Console.ReadLine();
        }

        //En static som skriver ut mellanslag mellan varje char
        static void WriteCharArray(char[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
