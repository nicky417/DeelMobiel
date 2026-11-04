// Scooter.cs
namespace DeelMobiel;

public class Scooter : ElektrischVoertuig
{
    private const decimal Starttarief = 1.00m;
    private const decimal PrijsPerMinuut = 0.25m;

    public string Kenteken { get; }

    public Scooter(string id, string merk, string kenteken, int accuPercentage)
        : base(id, merk, accuPercentage)
    {
        Kenteken = kenteken;
    }

    public override decimal BerekenPrijs(int minuten) => Starttarief + minuten * PrijsPerMinuut;

    public override string ToString() => $"{base.ToString()}, kenteken {Kenteken}";
}