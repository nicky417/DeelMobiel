// Voertuig.cs
namespace DeelMobiel;

public abstract class Voertuig
{
    public string Id { get; }
    public string Merk { get; }
    public bool IsBeschikbaar { get; set; } = true;

    protected Voertuig(string id, string merk)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Id mag niet leeg zijn.", nameof(id));
        }
        Id = id;
        Merk = merk;
    }

    public abstract decimal BerekenPrijs(int minuten);

    public override string ToString() =>
        $"{GetType().Name} {Id} ({Merk}) - {(IsBeschikbaar ? "beschikbaar" : "verhuurd")}";
}