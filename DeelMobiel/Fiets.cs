// Fiets.cs
namespace DeelMobiel;

public class Fiets : Voertuig
{
    private const decimal PrijsPerMinuut = 0.10m;

    public int Versnellingen { get; }

    public Fiets(string id, string merk, int versnellingen) : base(id, merk)
    {
        Versnellingen = versnellingen;
    }

    public override decimal BerekenPrijs(int minuten) => minuten * PrijsPerMinuut;

    public override string ToString() => $"{base.ToString()}, {Versnellingen} versnellingen";
}