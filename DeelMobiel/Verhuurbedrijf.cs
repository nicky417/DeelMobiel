// Verhuurbedrijf.cs
namespace DeelMobiel;

public sealed class Verhuurbedrijf
{
    // Singleton: Lazy<T> maakt het object pas bij eerste gebruik aan en is thread-safe.
    private static readonly Lazy<Verhuurbedrijf> _instance = new(() => new Verhuurbedrijf());
    public static Verhuurbedrijf Instance => _instance.Value;

    private readonly List<Voertuig> _voertuigen = new();

    private Verhuurbedrijf() { }

    public ILogger Logger { get; set; } = new ConsoleLogger();

    public IReadOnlyList<Voertuig> Voertuigen => _voertuigen;

    public void VoegToe(Voertuig voertuig)
    {
        ArgumentNullException.ThrowIfNull(voertuig);
        _voertuigen.Add(voertuig);
        Logger.Info($"Toegevoegd: {voertuig.Id}");
    }

    /// <exception cref="VoertuigNietBeschikbaarException">
    /// Als het voertuig niet bestaat, al verhuurd is of een te lege accu heeft.
    /// </exception>
    public void Huur(string id)
    {
        Voertuig voertuig = Zoek(id) ?? throw Weiger(id, $"Voertuig {id} bestaat niet.");

        if (!voertuig.IsBeschikbaar)
        {
            throw Weiger(id, $"Voertuig {id} is al verhuurd.");
        }
        if (voertuig is IOplaadbaar oplaadbaar && oplaadbaar.AccuPercentage < IOplaadbaar.MinimaleAccu)
        {
            throw Weiger(id, $"Accu van {id} is te leeg ({oplaadbaar.AccuPercentage}%).");
        }

        voertuig.IsBeschikbaar = false;
        Logger.Info($"Verhuurd: {id}");
    }

    public decimal Retourneer(string id, int minuten)
    {
        Voertuig voertuig = Zoek(id) ?? throw new ArgumentException($"Voertuig {id} bestaat niet.", nameof(id));
        voertuig.IsBeschikbaar = true;
        decimal prijs = voertuig.BerekenPrijs(minuten); // dynamische binding: de override van de subklasse
        Logger.Info($"Geretourneerd: {id} na {minuten} minuten");
        return prijs;
    }

    public void LaadAllesOp()
    {
        List<IOplaadbaar> oplaadbareVoertuigen = _voertuigen.OfType<IOplaadbaar>().ToList(); // upcasting via de interface
        foreach (IOplaadbaar voertuig in oplaadbareVoertuigen)
        {
            voertuig.LaadOp();
        }
        Logger.Info($"{oplaadbareVoertuigen.Count} voertuigen opgeladen");
    }

    private Voertuig? Zoek(string id) => _voertuigen.FirstOrDefault(v => v.Id == id);

    private VoertuigNietBeschikbaarException Weiger(string id, string melding)
    {
        Logger.Fout(melding);
        return new VoertuigNietBeschikbaarException(id, melding);
    }
}