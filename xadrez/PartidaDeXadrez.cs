using tabuleiro;
namespace xadrez
{
    public class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            ColocarPecas();
        }
        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            if (p == null) throw new TabuleiroException("Não há peça no endereço de origem.");
            p.IncrementarMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
        }
        private void ColocarPecas()
        {
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 1).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 2).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 1).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 2).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d', 2).ToPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 1).ToPosicao());

            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 7).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 8).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 7).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 8).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 7).ToPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }

}