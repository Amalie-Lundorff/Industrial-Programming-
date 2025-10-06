using System;

// Jeg bruger enum til tabellen og regner forskellen (p2 - p1), og laver en switch for at finde resultatet

// Enum: giver navne til tallene som ses i tabellen fra opgaven
enum Shape { Rock = 0, Paper = 1, Scissors = 2, Lizard = 3, Spock = 4 }

class Program
{
    static void Main()
    {
        // Tester alle kombinationerne 
        foreach (Shape p1 in Enum.GetValues<Shape>())
        foreach (Shape p2 in Enum.GetValues<Shape>())
        {
            int diff = (int)p2 - (int)p1;    //Forskellene som i tabellen
            string result;

            // Afgør udfaldet
            switch (diff)
            {
                case 0:
                    result = "tie";
                    break;

                // p1 vinder
                case -4:
                case -2:
                case 1:
                case 3:
                    result = "p1 wins";
                    break;

                // p1 taber
                case -3:
                case -1:
                case 2:
                case 4:
                    result = "p1 loses";
                    break;

                //Hvis diff ikke passer til nogen af de andre, sættes resultat til "unexpected"
                default:
                    result = "unexpected";
                    break;
            }

            //Viser spiller 1's valg og spiller 2's valg. Til slut vises resultatet på skærmen
            Console.WriteLine($"If p1: {p1} and p2: {p2} => {result}");
        }
    }
}

//Noter til funktioner i koderne 
    //enum Shape giver navne til tallene 0-4
    //p2-p1 giver forskellen, som matcher i tabellen fra opgaven
    //switch (diff) afgør resultatet (tie, win eller lose)
    //foreach tester alle de mulige kombinationer 