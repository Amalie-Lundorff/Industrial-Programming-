// Inputs fra brugeren
Console.Write("Enter username: ");  //Beder brugeren om at indtaste brugernavn
string username = Console.ReadLine() ?? "";  //Gemmer det, brugeren skriver som brugernavn – hvis der ikke bliver skrevet noget, gemmes det bare som tom tekst (Tom streng)

Console.Write("Enter password: ");   //Beder brugeren om at indtaste kodeord
string password = Console.ReadLine() ?? "";  //Gemmer det, som brugeren skriver som kodeord - hvis der ikke bliver skrevet niget, gemmes det bare som en tom tekst (Tom streng)

Console.Write("Enter userId: ");              //Beder brugere om at indtaste bruger-ID
uint userId = uint.TryParse(Console.ReadLine(), out var tmp) ? tmp : 0;  //Konventer input til tal

// Data fra Aktivitet 13 
var userIsAdmin = userId > 65536;   //Brugeren er admin, hvis bruger-ID er større end 65536
var usernameValid = username.Length >= 3;  //Brugernavnet er kun gyldig, hvis det har mindst 3 tegn

var passwordHasSpecial = password.IndexOfAny(new[] { '$', '|', '!' }) >= 0;   //Kodeordet skal indeholde specialtegn
var passwordLengthValid = userIsAdmin ? password.Length >= 20 : password.Length >= 16;  //Admin kræver 20 tegn ellers kræves 16 tegn for en "almindelig" bruger
var passwordValid = passwordHasSpecial && passwordLengthValid;  //Kodeordet er kun gyldig, hvis overstående betingelser er opfyldt

// Output
if (usernameValid && passwordValid)
{
    Console.WriteLine("Login successful! Both username and password are valid.");  //Bliver logget ind, hvis begge er gyldige
}
else
{
    if (!usernameValid)
        Console.WriteLine("Username is not valid. It must be at least 3 characters long.");   //Giver fejlbesked til brugernavn, hvis overstående betingelser ikke er opfyldt. 

    if (!passwordValid)
        Console.WriteLine("Password is not valid. It must contain $, | or @ and be long enough.");  //Fejlbesked til kodeord, hvis overstående betingelser ikke er opfyldt. 
}