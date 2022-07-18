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
                Tela.imprimirTabuleiro(partida.Tab);
                Console.WriteLine($"\n\tTurno: {partida.Turno}");
                Console.WriteLine($"Aguardando jogada: {partida.JogadorAtual}");

                Console.Write("\nDigite a posição de origem: ");
                Posicao origem = Tela.LerPosicao().ToPosicao();
                partida.ValidaPosicaoOrigem(origem);

                bool[,] movimentosPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                Console.Clear();
                Tela.imprimirTabuleiro(partida.Tab, movimentosPossiveis);

                Console.Write("\nDigite a posição de destino: ");
                Posicao destino = Tela.LerPosicao().ToPosicao();
                partida.ValidarPosicaoDestino(origem, destino);

                partida.RealizaJogada(origem, destino);
            }
            catch (TabuleiroException e)
            {
                Console.Write(e.Message);
                Thread.Sleep(2000);
            }
        }

    }
}