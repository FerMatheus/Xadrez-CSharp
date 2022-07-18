using tabuleiro;
using xadrez;
public class Program
{
    private static void Main(string[] args)
    {
        PartidaDeXadrez partida = new PartidaDeXadrez();

        while (!partida.Terminada)
        {
            Console.Clear();
            Tela.imprimirTabuleiro(partida.tab);

            Console.Write("\nDigite a posição de origem: ");
            Posicao origem = Tela.LerPosicao().ToPosicao();
            bool[,] movimentosPossiveis = partida.tab.peca(origem).MovimentosPossiveis();

            Console.Clear();
            Tela.imprimirTabuleiro(partida.tab, movimentosPossiveis);

            Console.Write("\nDigite a posição de destino: ");
            Posicao destino = Tela.LerPosicao().ToPosicao();

            try
            {
                partida.ExecutaMovimento(origem, destino);
            }
            catch (TabuleiroException e)
            {
                Console.Write(e.Message);
                Thread.Sleep(2000);
            }
        }

    }
}