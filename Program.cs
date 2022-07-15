using tabuleiro;
using xadrez;
public class Program
{
    private static void Main(string[] args)
    {


        Tabuleiro tab = new(8, 8);

        try
        {
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(0, 0));
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(1, 3));
            tab.ColocarPeca(new Rei(tab, Cor.Branca), new Posicao(0, 9));
        }
        catch (TabuleiroException e)
        {
            System.Console.WriteLine(e.Message);
        }

        Tela.imprimirTabuleiro(tab);
    }
}