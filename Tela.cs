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

                if (tab.peca(i, j) == null)
                {
                    Console.Write("- ");
                }
                else
                {
                    ImprimirPeca(tab.peca(i, j));
                }
            }
            System.Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }
    public static void ImprimirPeca(Peca peca)
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
    public static PosicaoXadrez LerPosicao()
    {
        string entrada = Console.ReadLine();
        int linha = int.Parse(entrada[1] + "");
        char coluna = entrada[0];
        return new PosicaoXadrez(coluna, linha);
    }
}
