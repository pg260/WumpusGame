namespace AreaRetangulo;

public class MontarTabuleiro
{
    public MontarTabuleiro(Tabuleiro tabuleiroAtual)
    {
        FundoTabuleiro = new List<string>();
        Tabuleiro = tabuleiroAtual;
        for (int i = 0; i < tabuleiroAtual.Area; i++)
        {
            string casa = " ";
            FundoTabuleiro.Add(casa);
        }

        Player = new Personagens(Tabuleiro.Area, Tabuleiro);
        Monstro = new Personagens(Tabuleiro.Area, Tabuleiro);
        Tesouro = new Personagens(Tabuleiro.Area, Tabuleiro);

        while (Player.Posicao == Monstro.Posicao || Player.Posicao == Tesouro.Posicao ||
            Tesouro.Posicao == Monstro.Posicao)
        {
            Player = new Personagens(Tabuleiro.Area, Tabuleiro);
            Monstro = new Personagens(Tabuleiro.Area, Tabuleiro);
            Tesouro = new Personagens(Tabuleiro.Area, Tabuleiro);
        }

        FundoTabuleiro[Player.Posicao] = "P";
        FundoTabuleiro[Monstro.Posicao] = "M";
        FundoTabuleiro[Tesouro.Posicao] = "T";

        Pontuacao = 1000;
        Fim = false;
    }

    public int Pontuacao { get; set; }
    
    public Personagens Player { get; set; }
    public Personagens Monstro { get; set; }
    public Personagens Tesouro { get; set; }
    public List<string> FundoTabuleiro { get; set; }
    private Tabuleiro Tabuleiro { get; set; }
    public bool Fim { get; set; }
    
    public void CriandoCasas()
    {
        Console.Clear();
        
        int contador = 0;

        for (int i = 0; i <= Tabuleiro.Altura + 1; i++)
        {
            if (i == 0 || i == Tabuleiro.Altura + 1)
            {
                for (int j = 0; j <= Tabuleiro.Largura + 1; j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
            else
            {
                Console.Write("#");
                for (int j = 0; j < Tabuleiro.Largura; j++)
                {
                    Console.Write(FundoTabuleiro[contador]);
                    contador++;
                }
                Console.WriteLine("#");
            }
        }

        if (Fim)
            Verificando();
        else
        {
            Movimentacao();
        }
    }

    public void Movimentacao()
    {
        Console.WriteLine("\n1 - Andar para esquerda");
        Console.WriteLine("2 - Andar para baixo");
        Console.WriteLine("3 - Andar para a direita");
        Console.WriteLine("4 - Andar para cima");
        Console.Write("Escolha a opção: ");

        short opcao = short.Parse(Console.ReadLine());
        
        CompletandoMovimentacao(opcao);
    }

    public void CompletandoMovimentacao(short opcao)
    {
        FundoTabuleiro[Player.Posicao] = " ";
        
        switch (opcao)
        {
            case 1:
            {
                if (Player.Posicao != 0 && Player.Posicao % Tabuleiro.Largura != 0)
                    Player.Posicao -= 1;
                else
                {
                    MovimentoInvalido();
                }
            }
                break;
            case 2:
            {
                if (Player.Linha != Tabuleiro.Altura - 1)
                {
                    Player.Posicao = Player.Posicao + Tabuleiro.Largura;
                    Player.Linha++;   
                }
                else
                {
                    MovimentoInvalido();
                }
            }
                break;
            case 3:
            {
                if(Player.Posicao != Tabuleiro.Largura - 1 && Player.Posicao + 1 % Tabuleiro.Largura != 0)
                    Player.Posicao += 1;
                else
                {
                    MovimentoInvalido();
                }
            }
                break;
            case 4:
            {
                if (Player.Linha != 0)
                {
                    Player.Posicao = Player.Posicao - Tabuleiro.Largura;
                    Player.Linha--;   
                }
                else
                {
                    MovimentoInvalido();
                }
            }
                break;
            default: CriandoCasas();
                break;
        }
        
        Pontuacao -= 10;
        FundoTabuleiro[Player.Posicao] = "P";
        
        Verificando(); 
        
        MovimentacaoMonstro();
    }

    public void MovimentacaoMonstro()
    {
        int mov = Tabuleiro.Area / 25;

        FundoTabuleiro[Monstro.Posicao] = " ";

        while (mov > 0)
        {
            if (Monstro.Linha < Player.Linha)
            {
                if (Monstro.Posicao + Tabuleiro.Largura != Tesouro.Posicao && Monstro.Linha != Tabuleiro.Altura - 1)
                {
                    Monstro.Posicao += Tabuleiro.Largura;
                    Monstro.Linha++;
                }
            }
            else if (Monstro.Posicao <= Player.Posicao)
            {
                if (Monstro.Posicao + 1 != Tesouro.Posicao || Monstro.Posicao % Tabuleiro.Largura - 1 != 0)
                    Monstro.Posicao += 1;
            }
            else if (Monstro.Linha > Player.Linha)
            {
                if (Monstro.Posicao - Tabuleiro.Largura != Tesouro.Posicao && Monstro.Linha != 0)
                {
                    Monstro.Posicao -= Tabuleiro.Largura;
                    Monstro.Linha--;
                }

            }
            else if (Monstro.Posicao >= Player.Posicao)
            {
                if (Monstro.Posicao - 1 != Tesouro.Posicao || Monstro.Posicao % Tabuleiro.Largura != 0 ||
                    Monstro.Posicao != 0)
                    Monstro.Posicao -= 1;
            }

            mov--;
            
            Verificando();
        }

        FundoTabuleiro[Monstro.Posicao] = "M";
        CriandoCasas();
    }

    public void Verificando()
    {
        if (Monstro.Posicao == Player.Posicao)
        {
            if (!Fim)
            {
                Pontuacao = 0;
                Fim = true;
                FundoTabuleiro[Player.Posicao] = "M";
                CriandoCasas();   
            }
            else
            {
                Console.WriteLine("\nFim de jogo, você perdeu ;(");
                Console.WriteLine($"Pontuação: {Pontuacao}");
                Console.WriteLine("Pressione qualquer botão para continuar");
                Console.ReadKey();
                Menu menu = new Menu();
                menu.Start(Tabuleiro);
            }
        }
        else if(Player.Posicao == Tesouro.Posicao)
        {
            if (!Fim)
            {
                Pontuacao += 500;
                Fim = true;
                CriandoCasas();
            }
            else
            {
                Console.WriteLine("\nFim de jogo, você ganhou :)");
                Console.WriteLine($"Pontuação: {Pontuacao}");
                Console.WriteLine("Pressione qualquer botão para continuar");
                Console.ReadKey();
                Menu menu = new Menu();
                menu.Start(Tabuleiro);
            }
        }
    }
    
    public void MovimentoInvalido()
    {
        Console.WriteLine("Movimento inválido.");
        Thread.Sleep(2000);
        FundoTabuleiro[Player.Posicao] = "P";
        CriandoCasas();
    }
}