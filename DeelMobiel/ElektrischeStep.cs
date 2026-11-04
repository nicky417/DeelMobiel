// ElektrischeStep.cs
namespace DeelMobiel;

public class ElektrischeStep : ElektrischVoertuig
{
    private const decimal Starttarief = 0.50m;
    private const decimal PrijsPerMinuut = 0.20m;

    public int MaxSnelheid { get; }

    public ElektrischeStep(string id, string merk, int maxSnelheid, int accuPercentage)
        : base(id, merk, accuPercentage)
    {
        MaxSnelheid = maxSnelheid;
    }

    public override decimal BerekenPrijs(int minuten) => Starttarief + minuten * PrijsPerMinuut;

    public override string ToString() => $"{base.ToString()}, max {MaxSnelheid} km/u";
}