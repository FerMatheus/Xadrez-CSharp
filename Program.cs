using tabuleiro;
using xadrez;
public class Program
{
    private static void Main(string[] args)
    {
        PartidaDeXadrez partida = new PartidaDeXadrez();

        while (!partida.Terminada)
        {
            try
            {

                Console.Clear();
                Tela.ImprimirPartida(partida);

                Console.Write("\nDigite a posição de origem: ");
                Posicao origem = Tela.LerPosicao().ToPosicao();
                try
                {
                    partida.ValidaPosicaoOrigem(origem);
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(2000);
                    continue;
                }

                bool[,] movimentosPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                Console.Clear();
                Tela.imprimirTabuleiro(partida.Tab, movimentosPossiveis);

                Console.Write("\nDigite a posição de destino: ");
                Posicao destino = Tela.LerPosicao().ToPosicao();
                try
                {
                    partida.ValidarPosicaoDestino(origem, destino);
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(2000);
                    continue;
                }

                try
                {
                    partida.RealizaJogada(origem, destino);
                }
                catch (TabuleiroException e)
                {
                    Console.Write(e.Message);
                    Thread.Sleep(2000);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(2000);
            }
        }
        Console.Clear();
        Tela.ImprimirPartida(partida);

    }
}