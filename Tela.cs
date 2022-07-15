using tabuleiro;

class Tela
{
    public static void imprimirTabuleiro(Tabuleiro tab)
    {
        for (int i = 0; i < tab.Linhas; i++)
        {
            for (int j = 0; j < tab.Colunas; j++)
            {
                if (tab.peca(i, j) == null)
                {
                    System.Console.Write("- ");
                }
                else
                {
                    Console.Write($"{tab.peca(i, j)} ");
                }
            }
            System.Console.WriteLine();
        }
    }
}
