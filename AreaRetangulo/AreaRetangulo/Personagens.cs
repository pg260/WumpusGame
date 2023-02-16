namespace AreaRetangulo;

public class Personagens
{
    public Personagens(int area, Tabuleiro tabuleiro)
    {
        Random random = new Random();
        Posicao = random.Next(0, area);
        int pos = Posicao;
        Linha = 0;
        if (Posicao > tabuleiro.Largura - 1)
        {
            while (pos >= tabuleiro.Largura)
            { 
                pos -= tabuleiro.Largura;
                Linha++;
            }
        }
        else
        {
            Linha = 0;
        }
    }

    public int Posicao { get; set; }
    public int Linha { get; set; }
}