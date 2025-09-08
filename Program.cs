namespace SparePartsInventoryAssistant
{
    internal static class Program
    {
        static void Main()
        {
            System.String[] inventory = { "hydraulic pump", "PLC module", "servo motor" };

            System.Console.WriteLine("Hej. Welcome to the spare parts inventory!");
            while (true)
            {
                System.Console.Write("Which part do you need? ");
                string input = System.Console.ReadLine() ?? string.Empty;

                // 1) Exact match (case-sensitive)
                if (System.Linq.Enumerable.Any(inventory, p => p == input))
                {
                    System.Console.WriteLine($"I've got {input} here for you 😊. Bye!");
                    return; // program exits
                }

                // 2) Special queries (case-insensitive)
                string q = input.ToLowerInvariant();
                if (q.Contains("any parts") || q.Contains("anything in stock") || q.Contains("in stock at all"))
                {
                    System.Console.WriteLine($"We have {inventory.Length} part(s)!");
                    foreach (var part in inventory)
                        System.Console.WriteLine(part);
                    continue;
                }

                // 3) Not found
                System.Console.WriteLine($"I am afraid we don't have any {input} in the inventory 😔");
            }
        }
    }
}