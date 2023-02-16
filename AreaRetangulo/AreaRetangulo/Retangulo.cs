namespace AreaRetangulo;

public class Retangulo
{
    public Retangulo(float baseRetangulo, float altura)
    {
        Area = (baseRetangulo * altura);
        
        Console.WriteLine($"A área do retangulo é {Area}");
    }
    public float Area { get; set; }
}