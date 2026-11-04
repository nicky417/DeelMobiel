// IOplaadbaar.cs
namespace DeelMobiel;

public interface IOplaadbaar
{
    const int MinimaleAccu = 20;

    int AccuPercentage { get; }
    void LaadOp();
}