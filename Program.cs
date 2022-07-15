using tabuleiro;
public class Program
{
    private static void Main(string[] args)
    {
        Posicao P;

        P = new Posicao(3, 4);
        Console.WriteLine($"Posição: {P}");

        Tabuleiro tab = new(8, 8);

        Tela.imprimirTabuleiro(tab);
    }
}