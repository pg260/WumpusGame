namespace AreaRetangulo;

public class Tabuleiro
{
    public Tabuleiro()
    {
        
    }
    public Tabuleiro(string nome ,int altura, int largura)
    {
        Nome = nome;
        Altura = altura;
        Largura = largura;
        Area = altura * largura;
    }

    public int Altura { get; set; }
    public int Largura { get; set; }
    public string Nome { get; set; }
    public int Area { get; set; }
    
}