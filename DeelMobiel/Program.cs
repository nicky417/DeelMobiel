// Program.cs
using DeelMobiel;

// 1. Singleton
Verhuurbedrijf bedrijf = Verhuurbedrijf.Instance;
Verhuurbedrijf ookBedrijf = Verhuurbedrijf.Instance;
Console.WriteLine($"Zelfde object: {ReferenceEquals(bedrijf, ookBedrijf)}");

// 2. Objecten aanmaken (upcasting via de abstracte klasse)
Voertuig fiets = new Fiets("F1", "Gazelle", 7);
Voertuig scooter = new Scooter("S1", "Niu", "DX-123-B", 80);
Voertuig step = new ElektrischeStep("E1", "Segway", 25, 10);
bedrijf.VoegToe(fiets);
bedrijf.VoegToe(scooter);
bedrijf.VoegToe(step);

try
{
    // 3. en 4. Huren en retourneren
    bedrijf.Huur("F1");
    Console.WriteLine($"Prijs fiets: € {bedrijf.Retourneer("F1", 30):0.00}");
    bedrijf.Huur("S1");
    Console.WriteLine($"Prijs scooter: € {bedrijf.Retourneer("S1", 20):0.00}");

    // 5. Step met lege accu
    bedrijf.Huur("E1");
}
catch (VoertuigNietBeschikbaarException ex)
{
    Console.WriteLine($"Melding aan klant: {ex.Message}");
}

// 6. Opladen en opnieuw proberen
bedrijf.LaadAllesOp();
try
{
    bedrijf.Huur("E1");
}
catch (VoertuigNietBeschikbaarException ex)
{
    Console.WriteLine($"Melding aan klant: {ex.Message}");
}

// 7. Overzicht: per object wordt de juiste ToString() aangeroepen
foreach (Voertuig voertuig in bedrijf.Voertuigen)
{
    Console.WriteLine(voertuig);
}