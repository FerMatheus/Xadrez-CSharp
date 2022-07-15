using tabuleiro;
using xadrez;
public class Program
{
    private static void Main(string[] args)
    {


        Tabuleiro tab = new(8, 8);

        tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(0, 0));
        tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(1, 3));
        tab.ColocarPeca(new Rei(tab, Cor.Branca), new Posicao(2, 4));

        Tela.imprimirTabuleiro(tab);
    }
}