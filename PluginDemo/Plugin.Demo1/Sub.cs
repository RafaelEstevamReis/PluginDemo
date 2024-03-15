using Plugin.Lib.Interfaces;

namespace Plugin.Demo1;

public class Sub : IOperation
{
    public string Name => "Sub";

    public int Calculate(int A, int B)
    {
        return A - B;
    }
}
