// VoertuigNietBeschikbaarException.cs
namespace DeelMobiel;

public class VoertuigNietBeschikbaarException : Exception
{
    public string VoertuigId { get; }

    public VoertuigNietBeschikbaarException(string voertuigId, string melding) : base(melding)
    {
        VoertuigId = voertuigId;
    }
}