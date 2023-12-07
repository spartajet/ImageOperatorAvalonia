namespace ImageOperator.Core;

public interface IImageOperator
{
    public string GetName();

    public Task Run();

    public void Stop();
    // public Func<T, TV> GetFunc<T, TV>(string name);
}