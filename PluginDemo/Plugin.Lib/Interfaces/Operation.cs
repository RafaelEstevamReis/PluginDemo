namespace Plugin.Lib.Interfaces;

/// <summary>
/// Interface to be implemented by the plugins and called by the Host
/// </summary>
public interface IOperation
{
    public string Name { get; }
    public int Calculate(int A, int B);
}
