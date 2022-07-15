using tabuleiro;
using xadrez;
public class Program
{
    private static void Main(string[] args)
    {
        Tabuleiro tab = new(8, 8);
        PosicaoXadrez pos = new PosicaoXadrez('c', 7);
        System.Console.WriteLine(pos);

        System.Console.WriteLine(pos.ToPosicao());
        //Tela.imprimirTabuleiro(tab);
    }
}