namespace AreaRetangulo;

public class Start
{
    public void Menu()
    {
        Console.WriteLine("=====Menu=====");
        Console.Write("Digite a base da altura: ");
        float baseRetangulo = float.Parse(Console.ReadLine());
        Console.Write("Digite a altura: ");
        float altura = float.Parse(Console.ReadLine());

        Retangulo retangulo = new Retangulo(baseRetangulo, altura);
    }
}