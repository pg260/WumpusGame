using System.Security.Cryptography;

namespace AreaRetangulo;

public class Menu
{
    public void Start(Tabuleiro tabuleiroAtual)
    {
        Console.Clear();
        Console.WriteLine("=====Menu=====\n");
        Console.WriteLine($"Dificuldade: {tabuleiroAtual.Nome}\n");
        Console.WriteLine("---Opções---");
        Console.WriteLine("1 - Iniciar");
        Console.WriteLine("2 - Definir dificuldade");
        Console.WriteLine("3 - Sair");
        Console.Write("Digite a opção escolhida: ");

        short posicao = short.Parse(Console.ReadLine());

        switch (posicao)
        {
            case 1:
            {
                MontarTabuleiro montarTabuleiro = new MontarTabuleiro(tabuleiroAtual);
                montarTabuleiro.CriandoCasas();
            }; 
                break;
            case 2: DefinindoDificuldade(tabuleiroAtual);
                break;
            case 3: Environment.Exit(0);
                break;
            default: Start(tabuleiroAtual); 
                break;
        }
    }

    public void DefinindoDificuldade(Tabuleiro tabuleiroAtual)
    {
        Console.Clear();
        Console.WriteLine($"Dificuldade: {tabuleiroAtual.Nome}\n");
        Console.WriteLine("---Opções---");
        Console.WriteLine("1 - Fácil");
        Console.WriteLine("2 - Normal");
        Console.WriteLine("3 - Difícil");
        Console.Write("Escolha a dificuldade: ");
        
        short dificuldade = short.Parse(Console.ReadLine());

        switch (dificuldade)
        {
            //facil
            case 1: Start(Program.TabuleiroFacil);
                break;
            //medio
            case 2: Start(Program.TabuleiroMedio);
                break;
            //dificl
            case 3: Start(Program.TabuleiroDificil);
                break;
            default: Start(Program.TabuleiroFacil);
                break;
        }
    }
}