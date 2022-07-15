using tabuleiro;
using xadrez;
public class Program
{
    private static void Main(string[] args)
    {
        Tabuleiro tab = new(8, 8);
        PosicaoXadrez pos = new PosicaoXadrez('c', 7);
        Peca peca = new Rei(tab, Cor.Branca);
        System.Console.WriteLine(pos);
        try
        {
            tab.ColocarPeca(peca, pos.ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('f', 2).ToPosicao());
        }
        catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
        }
        Tela.imprimirTabuleiro(tab);
    }
}