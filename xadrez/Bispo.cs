using tabuleiro;

namespace xadrez
{
    public class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        public override string ToString()
        {
            return "B";
        }

        public bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentoPossiveis = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new(0, 0);
            // Noroeste
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentoPossiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) break;
                pos.Linha--;
                pos.Coluna--;
            }
            // Nordeste
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentoPossiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) break;
                pos.Linha--;
                pos.Coluna++;
            }
            // Sudeste
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentoPossiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) break;
                pos.Linha++;
                pos.Coluna++;
            }
            // Sudoeste
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentoPossiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) break;
                pos.Linha++;
                pos.Coluna--;
            }
            return movimentoPossiveis;
        }
    }
}