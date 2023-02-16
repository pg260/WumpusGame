using System;

namespace AreaRetangulo
{
    class Program
    {
        public static Tabuleiro TabuleiroFacil = new("Facil", 5, 5);
        public static Tabuleiro TabuleiroMedio = new("Medio", 5, 10);
        public static Tabuleiro TabuleiroDificil = new("Dificil", 5, 15);

        static void Main(string[] args)
        {
            
            Menu menu = new Menu();
            menu.Start(TabuleiroFacil);
        }        
    }
}