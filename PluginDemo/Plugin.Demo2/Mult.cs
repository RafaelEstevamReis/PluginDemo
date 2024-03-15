using Plugin.Lib.Interfaces;

namespace Plugin.Demo2;

public class Mult : IOperation
{
    public string Name => "Mult";

    public int Calculate(int A, int B)
    {
        return A * B;
    }
}