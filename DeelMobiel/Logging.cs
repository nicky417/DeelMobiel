// Logging.cs (ILogger en ConsoleLogger)
namespace DeelMobiel;

public interface ILogger
{
    void Info(string melding);
    void Fout(string melding);
}

public class ConsoleLogger : ILogger
{
    public void Info(string melding) => Console.WriteLine($"[INFO] {melding}");
    public void Fout(string melding) => Console.WriteLine($"[FOUT] {melding}");
}