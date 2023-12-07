using ImageOperator.Core;
using ImageOperator.Core.Attributes;
using OpenCvSharp;

namespace PluginDemo;

public class ImageOperatorDemo : IImageOperator
{
    [In] [CanbeDisplay]
    public Mat? InputMat { get; set; }

    [Out] [CanbeDisplay]
    public Mat? OutputMat { get; set; }

    [Parameter]
    public int Value { get; set; }


    
    /// <summary>
    /// Returns the name.
    /// </summary>
    /// <returns>The name.</returns>
    public string GetName()
    {
        // Return null as the name is not available.
        return "Demo";
    }

    /// <inheritdoc />
    public Task Run()
    {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public void Stop()
    {
    }
}