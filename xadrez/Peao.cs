using tabuleiro;

namespace xadrez
{
    public class Peao : Peca
    {
        private PartidaDeXadrez partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }
        private bool Livre(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null;
        }
        private bool TemInimigo(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new(0, 0);

            if (Cor.Equals(Cor.Branca))
            {
                // Movimento
                pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.VerificaPosicao(pos) && Livre(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirPosicao(Posicao.Linha - 2, Posicao.Coluna);
                if (Tab.VerificaPosicao(pos) && Livre(pos) && qtdeMovimentos == 0)
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                //Captura
                pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.VerificaPosicao(pos) && TemInimigo(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.VerificaPosicao(pos) && TemInimigo(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.VerificaPosicao(esquerda) && TemInimigo(esquerda) && partida.VulneravelEnPassant.Equals(Tab.Peca(esquerda)))
                    {
                        movimentosPossiveis[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.VerificaPosicao(direita) && TemInimigo(direita) && partida.VulneravelEnPassant.Equals(Tab.Peca(direita)))
                    {
                        movimentosPossiveis[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            }
            else
            {
                // Movimento
                pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.VerificaPosicao(pos) && Livre(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirPosicao(Posicao.Linha + 2, Posicao.Coluna);
                if (Tab.VerificaPosicao(pos) && Livre(pos) && qtdeMovimentos == 0)
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                //Captura
                pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.VerificaPosicao(pos) && TemInimigo(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.VerificaPosicao(pos) && TemInimigo(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.VerificaPosicao(esquerda) && TemInimigo(esquerda) && partida.VulneravelEnPassant == Tab.Peca(esquerda))
                    {
                        movimentosPossiveis[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.VerificaPosicao(direita) && TemInimigo(direita) && partida.VulneravelEnPassant == Tab.Peca(direita))
                    {
                        movimentosPossiveis[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }
            return movimentosPossiveis;
        }
    }
}