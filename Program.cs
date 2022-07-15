using tabuleiro;
using xadrez;
public class Program
{
    private static void Main(string[] args)
    {
        PartidaDeXadrez partida = new PartidaDeXadrez();

        Tela.imprimirTabuleiro(partida.tab);
    }
}