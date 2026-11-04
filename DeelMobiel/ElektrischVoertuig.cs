// ElektrischVoertuig.cs
namespace DeelMobiel;

// Gemeenschappelijke accu-logica op één plek: geen dubbele code in Scooter en ElektrischeStep.
public abstract class ElektrischVoertuig : Voertuig, IOplaadbaar
{
    private int _accuPercentage;

    protected ElektrischVoertuig(string id, string merk, int accuPercentage) : base(id, merk)
    {
        AccuPercentage = accuPercentage;
    }

    public int AccuPercentage
    {
        get => _accuPercentage;
        set
        {
            if (value is < 0 or > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Accupercentage moet tussen 0 en 100 liggen.");
            }
            _accuPercentage = value;
        }
    }

    public void LaadOp() => AccuPercentage = 100;

    public override string ToString() => $"{base.ToString()}, accu {AccuPercentage}%";
}