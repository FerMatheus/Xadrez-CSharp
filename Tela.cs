using tabuleiro;
using xadrez;

class Tela
{
    public static void imprimirTabuleiro(Tabuleiro tab)
    {
        for (int i = 0; i < tab.Linhas; i++)
        {
            Console.Write($"{8 - i} ");
            for (int j = 0; j < tab.Colunas; j++)
            {
                ImprimirPeca(tab.Peca(i, j));
            }
            System.Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }
    public static void imprimirTabuleiro(Tabuleiro tab, bool[,] movimentosPossiveis)
    {
        ConsoleColor fundoOriginal = Console.BackgroundColor;
        ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
        for (int i = 0; i < tab.Linhas; i++)
        {
            Console.Write($"{8 - i} ");
            for (int j = 0; j < tab.Colunas; j++)
            {
                if (movimentosPossiveis[i, j])
                {
                    Console.BackgroundColor = fundoAlterado;
                }
                else
                {
                    Console.BackgroundColor = fundoOriginal;
                }
                ImprimirPeca(tab.Peca(i, j));
                Console.BackgroundColor = fundoOriginal;
            }
            System.Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }
    public static void ImprimirPeca(Peca peca)
    {
        if (peca == null)
        {
            Console.Write("- ");
        }
        else
        {
            if (peca.Cor == Cor.Branca)
            {
                Console.Write($"{peca} ");
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{peca} ");
                Console.ForegroundColor = aux;
            }
        }
    }
    public static PosicaoXadrez LerPosicao()
    {
        string entrada = Console.ReadLine();
        int linha = int.Parse(entrada[1] + "");
        char coluna = entrada[0];
        return new PosicaoXadrez(coluna, linha);
    }
}
