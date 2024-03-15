using Plugin.Lib.Interfaces;

namespace Plugin.Demo1;

public class Sum : IOperation
{
    public string Name => "Sum";

    public int Calculate(int A, int B)
    {
        return A + B;
    }
}
