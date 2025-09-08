using System;
using System.Globalization;

const double CapPerMotor = 5.6;   //Konstant - Hver motor kan bære 5.6 kg

int motors;
while (true)   //Loop indtil vi får gyldigt input
{
    Console.Write("How many motors are carrying the packages? ");
    if (int.TryParse(Console.ReadLine(), out motors) && motors > 0) break;   //Hvis succes - Loop stopper
    Console.WriteLine("Please enter a whole number > 0.");   //Ellers prøv igen
}

double packages;
while (true)   //Loop indtil vi får gyldigt input 
{
    Console.Write("How many kg of packages do we expect? ");
    var s = (Console.ReadLine() ?? "").Replace(',', '.');    //Tillader både komma og punktum
    if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out packages)) break;
    Console.WriteLine("Please enter a valid number.");
}

// Her tjekkes om vægten pr. motor er ≤ 5,6 kg
Console.WriteLine(packages / motors <= CapPerMotor
    ? "Yes! The conveyor belt can carry the packages."
    : "No. The conveyor belt cannot carry the packages.");