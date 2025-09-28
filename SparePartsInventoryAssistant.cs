using System;
using System.Linq;

internal class SparePartsInventoryAssistant
{
    static void Main()
    {
        // Array med dele i lageret
        string[] inventory = { "hydraulic pump", "PLC module", "servo motor" };

        Console.WriteLine("Hej. Welcome to the spare parts inventory!");

        bool found = false; // stopper programmet når vi har fundet en del

        // Loop: bliv ved indtil en del er fundet
        while (!found)
        {
            Console.WriteLine("Which part do you need?");
            string input = (Console.ReadLine() ?? "").Trim();

            // 1) Er input nøjagtigt en reservedel?
            if (inventory.Contains(input))
            {
                Console.WriteLine($"I've got {input} here for you 😊");
                found = true; // afslutter loopen
            }
            // 2) Er input en specialforespørgsel?
            else if (input.Equals("Do you actually have any parts?", StringComparison.OrdinalIgnoreCase) ||
                     input.Equals("Is there anything in stock at all?", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"We have {inventory.Length} part(s)!");
                foreach (var part in inventory)
                    Console.WriteLine(part);
            }
            // 3) Ellers: vi har ikke delen
            else
            {
                Console.WriteLine($"I am afraid we don't have any {input} in the inventory 😔");
            }
        }
    }
}