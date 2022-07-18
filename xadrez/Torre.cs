using tabuleiro;

namespace xadrez
{
    public class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        private bool PodeMover(Posicao pos)
        {
            Peca peca = Tab.peca(pos);
            return peca == null || peca.Cor != this.Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);
            // Cima
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor) break;
                pos.Linha -= 1;
            }
            // Direita
            pos.DefinirPosicao(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor) break;
                pos.Coluna += 1;
            }
            // Baixo
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor) break;
                pos.Linha += 1;
            }
            // Direita
            pos.DefinirPosicao(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor) break;
                pos.Coluna -= 1;
            }

            return movimentosPossiveis;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}