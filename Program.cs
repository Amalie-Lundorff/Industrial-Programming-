namespace ConveyorBeltCapacityCheck
{
    internal static class Program
    {
        private const double CapacityPerMotorKg = 5.6;

        static void Main()
        {
            Console.Write("How many motors are carrying the packages? ");
            var motorsInput = Console.ReadLine();
            Console.Write("How many kg of packages do we expect? ");
            var weightInput = Console.ReadLine();

            
            if (!int.TryParse(motorsInput, NumberStyles.Integer, ci, out var motors) || motors <= 0)
            {
                Console.WriteLine("Invalid motors input.");
                return;
            }

            if (!double.TryParse(weightInput, NumberStyles.Float, ci, out var totalWeight) || totalWeight < 0)
            {
                Console.WriteLine("Invalid packages weight input.");
                return;
            }

            var capacity = motors * CapacityPerMotorKg;
            if (totalWeight / motors <= CapacityPerMotorKg + 1e-9) // lille tolerance
                Console.WriteLine("Yes! The conveyor belt can carry the packages.");
            else
                Console.WriteLine("No. The conveyor belt cannot carry the packages.");
        }
    }
}